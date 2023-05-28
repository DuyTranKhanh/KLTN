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
    /// Interaction logic for DoiSan_View.xaml
    /// </summary>
    public partial class DoiSan_View : Window
    {
        public DoiSan_View()
        {
            InitializeComponent();
            Replace_Field_ViewModel vm = new Replace_Field_ViewModel();
            DataContext = vm;
        }
    }
}
