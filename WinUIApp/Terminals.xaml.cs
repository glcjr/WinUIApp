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
    public sealed partial class Terminals : Page
    {
        public Terminals()
        {
            this.InitializeComponent();
        }
        private void btnTerm1_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                string buttonpicked = btn.Name.Replace("btn", "").Replace("Term", "Terminal ");
                
                Frame.Navigate(typeof(ChooseUser), buttonpicked);
            }
            catch (Exception ex)
            {
                string mess = ex.Message;
                txtMessage.Text = mess;
            }
        }
    }
}
