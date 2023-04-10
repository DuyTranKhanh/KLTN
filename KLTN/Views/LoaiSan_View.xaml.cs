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
    /// Interaction logic for KhuVuc_SanBanh_View.xaml
    /// </summary>
    public partial class KhuVuc_SanBanh_View : Window
    {
        public KhuVuc_SanBanh_View()
        {
            InitializeComponent();
            LoaiSan_ViewModel vm = new LoaiSan_ViewModel();
            DataContext = vm;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            YardView temp = new YardView();
            temp.Show();
            this.Close();
        }
    }
}
