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
    /// Interaction logic for NewAlarm.xaml
    /// </summary>
    public partial class NewAlarm : Window
    {
        public NewAlarm()
        {
            InitializeComponent();
        }

        private void confirm_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInput())
            {
                //TODO
            }
        }

        private void confirm_MouseLeave(object sender, MouseEventArgs e)
        {
            confirm.Background = new SolidColorBrush(Colors.LawnGreen);
            confirm.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void confirm_MouseEnter(object sender, MouseEventArgs e)
        {
            confirm.Background = new SolidColorBrush(Colors.LightGreen);
            confirm.Foreground = new SolidColorBrush(Colors.LimeGreen);
        }

        private void cancel_MouseLeave(object sender, MouseEventArgs e)
        {
            cancel.Background = new SolidColorBrush(Colors.OrangeRed);
            cancel.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void cancel_MouseEnter(object sender, MouseEventArgs e)
        {
            cancel.Background = new SolidColorBrush(Colors.Red);
            cancel.Foreground = new SolidColorBrush(Colors.Red);
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool ValidateInput()
        {
            bool retVal = true;

            //validacija polja Alarm name
            if (String.IsNullOrWhiteSpace(AlarmNameTxt.Text))
            {
                AlarmNameTxt.BorderBrush = Brushes.Red;
                AlarmVal.Visibility = Visibility.Visible;
                retVal = false;
            }
            else
            {
                AlarmNameTxt.ClearValue(Border.BorderBrushProperty);
                AlarmVal.Visibility = Visibility.Hidden;
            }

            //validacija polja Message
            if (String.IsNullOrWhiteSpace(MessageTxt.Text))
            {
                MessageTxt.BorderBrush = Brushes.Red;
                MessageVal.Visibility = Visibility.Visible;
                retVal = false;
            }
            else
            {
                MessageTxt.ClearValue(Border.BorderBrushProperty);
                MessageVal.Visibility = Visibility.Hidden;
            }


            //validacija polja Initial Value
            if (String.IsNullOrWhiteSpace(LimitValueTxt.Text))
            {
                LimitValueTxt.BorderBrush = Brushes.Red;
                LimitValueVal.Visibility = Visibility.Visible;
                LimitValueVal.Text = "Limit value must be a number";
                retVal = false;
            }
            else
            {
                double limitValue;
                if (Double.TryParse(LimitValueTxt.Text, out limitValue))
                {
                    if (limitValue <= 0)
                    {
                        LimitValueTxt.BorderBrush = Brushes.Red;
                        LimitValueVal.Text = "Limit Value must be a positive number";               //da li mora?
                        LimitValueVal.Visibility = Visibility.Visible;
                        retVal = false;
                    }
                    else
                    {
                        LimitValueTxt.ClearValue(Border.BorderBrushProperty);
                        LimitValueVal.Visibility = Visibility.Hidden;
                    }
                }
                else
                {
                    LimitValueTxt.BorderBrush = Brushes.Red;
                    LimitValueVal.Visibility = Visibility.Visible;
                    LimitValueVal.Text = "Limit Value must be a positive number";
                    retVal = false;
                }
            }

            //validacija polja Type
            if(AlarmAbove.IsChecked == false & AlarmBelow.IsChecked == false)
            {
                TypeVal.Text = "Please select type";
                TypeVal.Visibility = Visibility.Visible;
                retVal = false;
            }
            else
            {
                TypeVal.Visibility = Visibility.Hidden;
            }


            return retVal;
        }
    }
}
