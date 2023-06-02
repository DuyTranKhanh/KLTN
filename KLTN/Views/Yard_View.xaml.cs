using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using KLTN.ViewModel;

namespace KLTN.Views
{
    /// <summary>
    /// Interaction logic for YardView.xaml
    /// </summary>
    public partial class YardView : Window
    {
        public YardView()
        {
            InitializeComponent();
            Yard_ViewModel vm = new Yard_ViewModel();
            DataContext = vm;
        }

        private void OpenDanhSachKhachHang(object sender, RoutedEventArgs e)
        {
            KhachHang_View temp = new KhachHang_View();
            temp.ShowDialog();
        }

        private void OpenWinDowInformation(object sender, RoutedEventArgs e)
        {
            ThongTinAccount_View temp = new ThongTinAccount_View();
            temp.ShowDialog();
        }

        private void BackToLoginWindow(object sender, RoutedEventArgs e)
        {
            Login_View temp = new Login_View();
            temp.Show();
            this.Close();
        }

        private void Close_Application_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void NuocUong_Click(object sender, RoutedEventArgs e)
        {
            NuocUong_View temp = new NuocUong_View();
            temp.Show();
            this.Close();
        }

        private void KhachHang_Click(object sender, RoutedEventArgs e)
        {
            KhachHang_View temp = new KhachHang_View();
            temp.ShowDialog();
        }

        private void DanhSach_San_Click(object sender, RoutedEventArgs e)
        {
            CRUD_DanhSachSan temp = new CRUD_DanhSachSan();
            temp.Show();
            this.Close();
        }

        private void DanhSach_BangGia_Click(object sender, RoutedEventArgs e)
        {
            CRUD_BangGia_San temp = new CRUD_BangGia_San();
            temp.Show();
            this.Close();
        }

        private void DanhSach_LoaiSan_Click(object sender, RoutedEventArgs e)
        {
            KhuVuc_SanBanh_View temp = new KhuVuc_SanBanh_View();
            temp.Show();
            this.Close();
        }

        private void DanhSach_NhanVien_Click(object sender, RoutedEventArgs e)
        {
            AccountEmployee_View temp = new AccountEmployee_View();
            temp.Show();
            this.Close();
        }

        private void DanhSach_Camera_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void DanhSach_DatSan_Click(object sender, RoutedEventArgs e)
        {
            DatLich_View temp = new DatLich_View();
            temp.ShowDialog();
        }

        private void DanhSach_HoaDon_Click(object sender, RoutedEventArgs e)
        {
            Invoice_View temp = new Invoice_View();
            temp.Show();
            this.Close();
        }
        private void DoiSan_Click(object sender, RoutedEventArgs e)
        {
            DoiSan_View temp = new DoiSan_View();
            temp.Show();
            this.Close();
        }

    }
}
