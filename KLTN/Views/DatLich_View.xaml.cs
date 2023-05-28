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
    /// Interaction logic for DatLich_View.xaml
    /// </summary>
    public partial class DatLich_View : Window
    {
        public DatLich_View()
        {
            InitializeComponent();
            DatSan_ViewModel vm = new DatSan_ViewModel();
            DataContext = vm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
