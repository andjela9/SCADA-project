using DataConcentrator;
using DataConcentrator.Tagovi;
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

        public static Handler Handler { get; set; }

        public static AI SelectedAI { get; set; }


        public MainWindow()
        {
            InitializeComponent();

            if(Handler == null)
            {
                Handler = new Handler();
            }
            Handler.LoadContext();
            Handler.PLC.StartPLCSimulator();
            Handler.StartAI();
            Handler.StartDI();

            dataGrid.ItemsSource = Handler.context.AnalogInputs;
            

        }

        private void newAI_Click(object sender, RoutedEventArgs e)
        {

        }

        private void new_Click(object sender, RoutedEventArgs e)
        {

        }

        private void remove_Click(object sender, RoutedEventArgs e)
        {

        }

        private void history_Click(object sender, RoutedEventArgs e)
        {

        }

        private void addresses_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
