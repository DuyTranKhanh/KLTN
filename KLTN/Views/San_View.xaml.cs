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
    /// Interaction logic for CRUD_DanhSachSan.xaml
    /// </summary>
    public partial class CRUD_DanhSachSan : Window
    {
        public CRUD_DanhSachSan()
        {
            InitializeComponent();
            San_ViewModel vm = new San_ViewModel();
            DataContext = vm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            KhuVuc_SanBanh_View khuVuc_SanBanh_View = new KhuVuc_SanBanh_View();
            //Visibility = Visibility.Hidden;
            khuVuc_SanBanh_View.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CRUD_BangGia_San obj = new CRUD_BangGia_San();
            obj.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
            
        }
    }
}
