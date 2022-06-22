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

namespace ScadaGUI
{
    /// <summary>
    /// Interaction logic for NewAI.xaml
    /// </summary>
    public partial class NewAI : Window
    {
        
        public NewAI()
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
            if (String.IsNullOrWhiteSpace(AINameTxt.Text))
            {
                AINameTxt.BorderBrush = Brushes.Red;
                AIVal.Visibility = Visibility.Visible;
                retVal = false;
            }
            else
            {
                AINameTxt.ClearValue(Border.BorderBrushProperty);
                AIVal.Visibility = Visibility.Hidden;
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
            //validacija polja barkod
            if (String.IsNullOrWhiteSpace(ScanTimeTxt.Text))
            {
                ScanTimeVal.Visibility = Visibility.Visible;
                ScanTimeVal.Text = "Scan time must be an integer";
                retVal = false;
            }
            else
            {
                int scanTime;
                if (Int32.TryParse(ScanTimeTxt.Text, out scanTime))
                {
                    if (scanTime <= 0)
                    {
                        ScanTimeTxt.BorderBrush = Brushes.Red;
                        ScanTimeVal.Text = "Scan time must be a positive integer";
                        ScanTimeVal.Visibility = Visibility.Visible;
                        retVal = false;
                    }
                    else
                    {
                        ScanTimeTxt.ClearValue(Border.BorderBrushProperty);
                        ScanTimeVal.Visibility = Visibility.Hidden;
                    }
                }
                else
                {
                    ScanTimeTxt.BorderBrush = Brushes.Red;
                    ScanTimeVal.Visibility = Visibility.Visible;
                    ScanTimeVal.Text = "Scan time must be a positive integer";
                    retVal = false;
                }
            }


            return retVal;
        }
    }
}