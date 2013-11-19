using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace timeToShutdown
{
    /// <summary>
    /// Set.xaml 的交互逻辑
    /// </summary>
    public partial class Set : Window
    {
        public Set()
        {
            InitializeComponent();
            maingrid.Background = MainWindow.MW.Background;

            this.Top = SystemParameters.PrimaryScreenHeight * 0.27;
            this.Left = SystemParameters.PrimaryScreenWidth * 0.35;
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        public void Select_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle r = (sender as Rectangle);
            MainWindow.MW.setBackGroup(r.Fill.ToString());
            maingrid.Background = r.Fill;
        }
    }
}
