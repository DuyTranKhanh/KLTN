using KLTN.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KLTN.Views
{
    /// <summary>
    /// Interaction logic for ThongTinAccount_View.xaml
    /// </summary>
    public partial class ThongTinAccount_View : Window
    {
        public ThongTinAccount_View()
        {
            InitializeComponent();
            ThongTinAccount_ViewModel vm = new ThongTinAccount_ViewModel();
            DataContext = vm;
        }
        public void CloseThisWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ShowHide_Click(object sender, RoutedEventArgs e)
        {
            if (ShowHide.Content == FindResource("EyeOff"))
            {
                ShowHide.Content = FindResource("EyeShow");
            }
            else
            {
                ShowHide.Content = FindResource("EyeOff");
            }
        }
    }
}
