using KLTN.Service;
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
        public AccountOfNhanVien_Service Database;
        public Login_View()
        {
            InitializeComponent();
            this.txtAccount.Focus();
            Database = new AccountOfNhanVien_Service();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            bool ressult = Database.Search(this.txtAccount.ToString(), this.txtPassword.ToString());
            
            //Login success
            if(ressult)
            {
                YardView temp = new YardView();
                temp.Show();
                MessageBox.Show("Đăng nhập thành công.");

                this.Close();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng. Xin nhập lại!");
                this.txtPassword.Clear();
                this.txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                bool ressult = Database.Search(this.txtAccount.Text.ToString(), this.txtPassword.Password.ToString());

                //Login success
                if (ressult)
                {
                    YardView temp = new YardView();
                    temp.Show();
                    MessageBox.Show("Đăng nhập thành công.");

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng. Xin nhập lại!");
                    this.txtPassword.Clear();
                    this.txtPassword.Focus();
                }
            }
        }
    }
}
