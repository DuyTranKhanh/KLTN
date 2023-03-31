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
using KLTN.ViewModel;

namespace KLTN.Views
{
    /// <summary>
    /// Interaction logic for CRUD_BangGia_San.xaml
    /// </summary>
    public partial class CRUD_BangGia_San : Window
    {
        public CRUD_BangGia_San()
        {
            InitializeComponent();
            BangGia_ViewModel vm = new BangGia_ViewModel();
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
            this.Close();
        }
    }
}
