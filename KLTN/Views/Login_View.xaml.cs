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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Login_View : Window
    {
        public Login_View()
        {
            InitializeComponent();
            Login_ViewModel vm = new Login_ViewModel();
            DataContext = vm;
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            bool ressult = ((Login_ViewModel)(this.DataContext)).IsValid;
            if(ressult)
            {
                YardView temp = new YardView();
                temp.Show();
                this.Close();
                MessageBox.Show("Login");
            }
        }
    }
}
