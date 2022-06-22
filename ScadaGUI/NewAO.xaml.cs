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

            //validacija polja Scan Time
            if (String.IsNullOrWhiteSpace(InitialValueTxt.Text))
            {
                InitialValueVal.Visibility = Visibility.Visible;
                InitialValueVal.Text = "Scan time must be an integer";
                retVal = false;
            }
            else
            {
                int initialValue;
                if (Int32.TryParse(InitialValueTxt.Text, out initialValue))
                {
                    if (initialValue <= 0)
                    {
                        InitialValueTxt.BorderBrush = Brushes.Red;
                        InitialValueVal.Text = "Scan time must be a positive integer";
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
                    InitialValueVal.Text = "Scan time must be a positive integer";
                    retVal = false;
                }
            }


            return retVal;
        }
    }
}
