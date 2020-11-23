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

namespace Praktika
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void bt_Kind_criteria_Click(object sender, RoutedEventArgs e)
        {
            Kind_criteria kind_Criteria = new Kind_criteria();
            kind_Criteria.Show();
            Hide();
        }

        private void bt_Criteria_Click(object sender, RoutedEventArgs e)
        {
            Criteria criteria = new Criteria();
            criteria.Show();
            Hide();
        }

        private void bt_Quality_control_Click(object sender, RoutedEventArgs e)
        {
            Quality_control quality_Control = new Quality_control();
            quality_Control.Show();
            Hide();
        }

        private void bt_Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void bt_Sopostavlenie_Click(object sender, RoutedEventArgs e)
        {
            new Sopostavl().Show();
            Hide();
        }

        private void bt_Tabel_Click(object sender, RoutedEventArgs e)
        {
            new Tabel().Show();
            Hide();
        }
    }
}
