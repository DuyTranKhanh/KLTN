using KLTN.ViewModel;
using System.Windows;

namespace KLTN.Views
{
    /// <summary>
    /// Interaction logic for AccountEmployee_View.xaml
    /// </summary>
    public partial class AccountEmployee_View : Window
    {
        public AccountEmployee_View()
        {
            InitializeComponent();
            AccountOfNhanVien_ViewModel vm = new AccountOfNhanVien_ViewModel();
            DataContext = vm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ShowHide_Click(object sender, RoutedEventArgs e)
        {
            if(ShowHide.Content == FindResource("EyeOff"))
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
