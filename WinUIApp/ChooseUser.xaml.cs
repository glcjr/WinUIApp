using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUIApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ChooseUser : Page
    {
        DataSet1TableAdapters.UserInfoTableAdapter tableadapt = new DataSet1TableAdapters.UserInfoTableAdapter();

        DataSet1 ds = new DataSet1();



        public ChooseUser()
        {
            this.InitializeComponent();            
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is string && !string.IsNullOrWhiteSpace((string)e.Parameter))
            {
                prepareform(e.Parameter.ToString());                
            }
            else
                prepareform("");

            base.OnNavigatedTo(e);
        }

        private void prepareform(string term)
        {
            txtMessage.Text = "Login for " + term;
            tableadapt.Fill(ds.UserInfo);
            foreach (var rec in ds.UserInfo)
            {
                ListViewItem itm = new ListViewItem();
                itm.Content = rec.UserName_vc;
                itm.FontSize = 30;
                lstUsers.Items.Add(itm);
            }
        }

        private void btnLogin_Tapped(object sender, TappedRoutedEventArgs e)
        {
            tableadapt.FillByUserPassword(ds.UserInfo, lblUser.Text, txtPassword.Text);
            if (ds.UserInfo.Any())
            {
                Frame.Navigate(typeof(MainMenu), "Welcome " + lblUser.Text);                
            }
            else
                txtMessage.Text = "Login Failed";
                
        }

        private void lstUsers_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ListViewItem itm = new ListViewItem();
            itm = (ListViewItem)lstUsers.SelectedItem;
            lblUser.Text = itm.Content.ToString();
        }
    }
}
