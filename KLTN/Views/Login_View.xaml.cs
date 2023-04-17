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
        public CurrentUser_Service _CurrentUser;
        public Login_View()
        {
            InitializeComponent();
            this.txtAccount.Focus();
            Database = new AccountOfNhanVien_Service();
            _CurrentUser = new CurrentUser_Service();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            int result = Database.Search(this.txtAccount.ToString(), this.txtPassword.ToString());
            
            //Khong co account nay
            if(result == 0)
            {
                MessageBox.Show("Không tồn tại account này!");
                this.txtPassword.Clear();
                this.txtAccount.Clear();
                this.txtAccount.Focus();
            }
            //Sai mk
            else if (result == -1)
            {
                MessageBox.Show("Sai thông tin mật khẩu! Xin nhập lại.");
                this.txtPassword.Clear();
                this.txtPassword.Focus();
            }
            //Trang thai khong hoat dong
            else if (result == -2)
            {
                MessageBox.Show("Trạng thái account hiện không hợp lệ! Vui lòng liên lạc với Admin để cập nhật.");
                this.txtPassword.Clear();
                this.txtAccount.Clear();
                this.txtAccount.Focus();
            }
            //Login success
            else if(result == 1)
            {
                YardView temp = new YardView();
                temp.Show();
                MessageBox.Show("Đăng nhập thành công.");
                var currentUser = Database.GetSingleItem(this.txtAccount.Text.ToString(), this.txtPassword.ToString());
                _CurrentUser.UpdateItem(currentUser);
                this.Close();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                int result = Database.Search(this.txtAccount.Text.ToString(), this.txtPassword.Password.ToString());

                //Khong co account nay
                if (result == 0)
                {
                    MessageBox.Show("Không tồn tại account này!");
                    this.txtPassword.Clear();
                    this.txtAccount.Clear();
                    this.txtAccount.Focus();
                }
                //Sai mk
                else if (result == -1)
                {
                    MessageBox.Show("Sai thông tin mật khẩu! Xin nhập lại.");
                    this.txtPassword.Clear();
                    this.txtPassword.Focus();
                }
                //Trang thai khong hoat dong
                else if (result == -2)
                {
                    MessageBox.Show("Trạng thái account hiện không hợp lệ! Vui lòng liên lạc với Admin để cập nhật.");
                    this.txtPassword.Clear();
                    this.txtAccount.Clear();
                    this.txtAccount.Focus();
                }
                //Login success
                else if (result == 1)
                {
                    YardView temp = new YardView();
                    temp.Show();
                    MessageBox.Show("Đăng nhập thành công.");
                    var currentUser = Database.GetSingleItem(this.txtAccount.Text.ToString(), this.txtPassword.ToString());
                    _CurrentUser.UpdateItem(currentUser);
                    this.Close();
                }
            }
        }

        private void ForgetPswBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Liên hệ với admin để có thể đổi lại mật khẩu!");
            this.txtPassword.Clear();
            this.txtAccount.Clear();
            this.txtAccount.Focus();
        }
    }
}
