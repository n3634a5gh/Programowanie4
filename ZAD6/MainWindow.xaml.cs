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

namespace ZAD6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Button_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            var button1 = sender as Button;

            var label = new Label();
            var num = panel.Children.Count;
            label.Content = num + 1;
            label.Width = 100;
            label.BorderBrush = new SolidColorBrush(Colors.Black);
            label.BorderThickness = new Thickness(1);
            label.HorizontalContentAlignment = HorizontalAlignment.Center;
            panel.Children.Add(label);
        }
    }
}
