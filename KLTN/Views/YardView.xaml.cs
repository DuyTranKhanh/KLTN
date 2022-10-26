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
using System.Windows.Navigation;
using System.Windows.Shapes;

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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CRUD_BangGia_San cRUD_BangGia_San = new CRUD_BangGia_San();
            //Visibility = Visibility.Hidden;
            cRUD_BangGia_San.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            CRUD_DanhSachSan temp = new CRUD_DanhSachSan();
            //Visibility = Visibility.Hidden;
            temp.ShowDialog();
        }
    }
}
