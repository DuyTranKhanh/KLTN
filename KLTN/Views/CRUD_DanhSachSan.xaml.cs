﻿using System;
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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            KhuVuc_SanBanh_View khuVuc_SanBanh_View = new KhuVuc_SanBanh_View();
            //Visibility = Visibility.Hidden;
            khuVuc_SanBanh_View.ShowDialog();
        }
    }
}
