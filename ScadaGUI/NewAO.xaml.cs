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

namespace ScadaGUI
{
    /// <summary>
    /// Interaction logic for NewAO.xaml
    /// </summary>
    public partial class NewAO : Window
    {
        public NewAO()
        {
            InitializeComponent();
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void confirm_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInput())
            {
                //TODO
            }
        }

        private void confirm_MouseEnter(object sender, MouseEventArgs e)
        {
            confirm.Background = new SolidColorBrush(Colors.LightGreen);
            confirm.Foreground = new SolidColorBrush(Colors.LimeGreen);
        }

        private void confirm_MouseLeave(object sender, MouseEventArgs e)
        {
            confirm.Background = new SolidColorBrush(Colors.LawnGreen);
            confirm.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void cancel_MouseEnter(object sender, MouseEventArgs e)
        {
            cancel.Background = new SolidColorBrush(Colors.Red);
            cancel.Foreground = new SolidColorBrush(Colors.Red);
        }

        private void cancel_MouseLeave(object sender, MouseEventArgs e)
        {
            cancel.Background = new SolidColorBrush(Colors.OrangeRed);
            cancel.Foreground = new SolidColorBrush(Colors.Black);
        }

        private bool ValidateInput()
        {
            bool retVal = true;

            //validacija polja AI name
            if (String.IsNullOrWhiteSpace(AONameTxt.Text))
            {
                AONameTxt.BorderBrush = Brushes.Red;
                AOVal.Visibility = Visibility.Visible;
                retVal = false;
            }
            else
            {
                AONameTxt.ClearValue(Border.BorderBrushProperty);
                AOVal.Visibility = Visibility.Hidden;
            }

            //validacija polja Description
            if (String.IsNullOrWhiteSpace(DescriptionTxt.Text))
            {
                DescriptionTxt.BorderBrush = Brushes.Red;
                DescriptionVal.Visibility = Visibility.Visible;
                retVal = false;
            }
            else
            {
                DescriptionTxt.ClearValue(Border.BorderBrushProperty);
                DescriptionVal.Visibility = Visibility.Hidden;
            }

            //validacija polja address
            if (String.IsNullOrWhiteSpace(AddressTxt.Text))
            {
                AddressTxt.BorderBrush = Brushes.Red;
                AddressVal.Visibility = Visibility.Visible;
                retVal = false;
            }
            else
            {
                AddressTxt.ClearValue(Border.BorderBrushProperty);
                AddressVal.Visibility = Visibility.Hidden;
            }

            //validacija polja Units
            if (String.IsNullOrWhiteSpace(UnitsTxt.Text))
            {
                UnitsTxt.BorderBrush = Brushes.Red;
                UnitsVal.Visibility = Visibility.Visible;
                retVal = false;
            }
            else
            {
                UnitsTxt.ClearValue(Border.BorderBrushProperty);
                UnitsVal.Visibility = Visibility.Hidden;
            }

            //validacija polja Initial Value
            if (String.IsNullOrWhiteSpace(InitialValueTxt.Text))
            {
                InitialValueVal.Visibility = Visibility.Visible;
                InitialValueVal.Text = "Scan time must be an integer";
                retVal = false;
            }
            else
            {
                double initialValue;
                if (Double.TryParse(InitialValueTxt.Text, out initialValue))
                {
                    if (initialValue <= 0)
                    {
                        InitialValueTxt.BorderBrush = Brushes.Red;
                        InitialValueVal.Text = "Initial Value must be a positive number";               //da li mora?
                        InitialValueVal.Visibility = Visibility.Visible;
                        retVal = false;
                    }
                    else
                    {
                        InitialValueTxt.ClearValue(Border.BorderBrushProperty);
                        InitialValueVal.Visibility = Visibility.Hidden;
                    }
                }
                else
                {
                    InitialValueTxt.BorderBrush = Brushes.Red;
                    InitialValueVal.Visibility = Visibility.Visible;
                    InitialValueVal.Text = "Initial Value must be a positive number";
                    retVal = false;
                }
            }

            return retVal;
        }
    }
}
