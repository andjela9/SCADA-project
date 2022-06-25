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

namespace ScadaGUI
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

        private void newAI_Click(object sender, RoutedEventArgs e)
        {
            NewAI newAI = new NewAI();
            newAI.ShowDialog();
        }

        private void newAO_Click(object sender, RoutedEventArgs e)
        {
            NewAO newAO = new NewAO();
            newAO.ShowDialog();
        }

        private void newDI_Click(object sender, RoutedEventArgs e)
        {
            NewDI newDI = new NewDI();
            newDI.ShowDialog();
        }

        private void newDO_Click(object sender, RoutedEventArgs e)
        {
            NewDO newDO = new NewDO();
            newDO.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        
    }
}
