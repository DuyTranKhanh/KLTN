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
    /// Interaction logic for Invoice_View.xaml
    /// </summary>
    public partial class Invoice_View : Window
    {
        public Invoice_View()
        {
            InitializeComponent();
            Invoice_ViewModel vm = new Invoice_ViewModel();
            DataContext = vm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            YardView temp = new YardView();
            temp.Show();
            this.Close();
        }
    }
}
