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

namespace CoronaUniversityDatabase
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        //    if (HelloButton.IsChecked == true)
        //    {
        //        MessageBox.Show("Hello");
        //    }
        //    else if (goodbye_button.IsChecked == true)
        //    {
        //        MessageBox.Show("Goodbye.");
        //    }
        }

        private void Goodbye_button_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
