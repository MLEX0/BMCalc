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

namespace BMICalc
{
    /// <summary>
    /// Логика взаимодействия для BmrWin.xaml
    /// </summary>
    public partial class BmrWin : Window
    {
        private double _Weight;
        private double _Age;
        private double _Growth;
        private double _Result;
        private int _Gender;
        private int _Joul = 0;

        public BmrWin()
        {
            InitializeComponent();
        }

        private void Calculation_Bmr()
        {
            _Age = Convert.ToDouble(boxAge.Text);
            _Growth = Convert.ToDouble(boxGrowth.Text);
            _Weight = Convert.ToDouble(boxWeight.Text);


            if (rdbWeightFunt.IsChecked == true)
            {
                _Weight = _Weight / 2.205;
            }

            if (rdbGenderMale.IsChecked == true)
            {
                _Gender = 1;
            }
            else
            {
                _Gender = 2;
            }


            if (rdbFormulaHarris.IsChecked == true)
            {
                _Result = CalculationClass.Calculation_BMR_Harris(_Weight, _Age, _Growth, _Gender);
            }

            if (rdbFormulaMaffin.IsChecked == true)
            {
                _Result = CalculationClass.Calculation_BMR_Maffin(_Weight, _Age, _Growth, _Gender);
            }



            if (cmbLevel.SelectedIndex == 1)
            {
                _Result = _Result * 1.2;
            }

            if (cmbLevel.SelectedIndex == 2)
            {
                _Result = _Result * 1.375;
            }

            if (cmbLevel.SelectedIndex == 3)
            {
                _Result = _Result * 1.4625;
            }

            if (cmbLevel.SelectedIndex == 4)
            {
                _Result = _Result * 1.550;
            }

            if (cmbLevel.SelectedIndex == 5)
            {
                _Result = _Result * 1.6375;
            }

            if (cmbLevel.SelectedIndex == 6)
            {
                _Result = _Result * 1.725;
            }

            if (cmbLevel.SelectedIndex == 7)
            {
                _Result = _Result * 1.9;
            }

            if (rdbResultDjoul.IsChecked == true)
            {
                _Result = _Result * 4.184;
                _Joul = 1;
            }
            else
            {
                _Joul = 0;
            }


            OutputWin outputWin = new OutputWin(_Result, _Joul);
            this.Hide();
            outputWin.ShowDialog();
            this.Show();
        }

        private void btnCount_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToDouble(boxAge.Text) > 0 && Convert.ToDouble(boxAge.Text) < 1000 
                && Convert.ToDouble(boxWeight.Text) > 0 && Convert.ToDouble(boxWeight.Text) < 1000
                && Convert.ToDouble(boxGrowth.Text) > 0 && Convert.ToDouble(boxGrowth.Text) < 1000)
            {
                Calculation_Bmr();
            }
        }

        private void boxAge_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789".IndexOf(e.Text) < 0;
        }

        private void boxWeight_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789".IndexOf(e.Text) < 0;
        }

        private void boxGrowth_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789".IndexOf(e.Text) < 0;
        }

        private void boxAge_GotFocus(object sender, RoutedEventArgs e)
        {
            if (boxAge.Text == "0")
            {
                boxAge.Text = "";
            }
        }

        private void boxAge_LostFocus(object sender, RoutedEventArgs e)
        {
            if (boxAge.Text == "")
            {
                boxAge.Text = "0";
            }
        }

        private void boxWeight_GotFocus(object sender, RoutedEventArgs e)
        {
            if (boxWeight.Text == "0")
            {
                boxWeight.Text = "";
            }
        }

        private void boxWeight_LostFocus(object sender, RoutedEventArgs e)
        {
            if (boxWeight.Text == "")
            {
                boxWeight.Text = "0";
            }
        }

        private void boxGrowth_GotFocus(object sender, RoutedEventArgs e)
        {
            if (boxGrowth.Text == "0")
            {
                boxGrowth.Text = "";
            }
        }

        private void boxGrowth_LostFocus(object sender, RoutedEventArgs e)
        {
            if (boxGrowth.Text == "")
            {
                boxGrowth.Text = "0";
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (Convert.ToDouble(boxAge.Text) > 0 && Convert.ToDouble(boxAge.Text) < 1000
                    && Convert.ToDouble(boxWeight.Text) > 0 && Convert.ToDouble(boxWeight.Text) < 1000
                    && Convert.ToDouble(boxGrowth.Text) > 0 && Convert.ToDouble(boxGrowth.Text) < 1000)
                {
                    Calculation_Bmr();
                }
            }

            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            StartWin startWin = new StartWin();
            this.Close();
            startWin.ShowDialog();
        }
    }
}
