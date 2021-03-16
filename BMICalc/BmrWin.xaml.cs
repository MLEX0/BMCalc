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
        private double _weight;
        private int _age;
        private double _growth;
        private double _result;
        private int _gender;
        private int _joul = 0;
        private int _errorcount = 0;

        public BmrWin()
        {
            InitializeComponent();
        }

        private void CalculationBmr()
        {
            _age = Convert.ToInt32(boxAge.Text);
            _growth = Convert.ToDouble(boxGrowth.Text);
            _weight = Convert.ToDouble(boxWeight.Text);


            if (rdbWeightFunt.IsChecked == true)
            {
                _weight = _weight / 2.205;
            }

            if (rdbGenderMale.IsChecked == true)
            {
                _gender = 1;
            }
            else
            {
                _gender = 2;
            }


            if (rdbFormulaHarris.IsChecked == true)
            {
                _result = CalculationClass.CalculationBMRHarris(_weight, _age, _growth, _gender);
            }

            if (rdbFormulaMaffin.IsChecked == true)
            {
                _result = CalculationClass.CalculationBMRMaffin(_weight, _age, _growth, _gender);
            }

            switch (cmbLevel.SelectedIndex)
            {
                case 1:
                    _result = _result * 1.2;
                    break;

                case 2:
                    _result = _result * 1.375;
                    break;

                case 3:
                    _result = _result * 1.4625;
                    break;

                case 4:
                    _result = _result * 1.550;
                    break;

                case 5:
                    _result = _result * 1.6375;
                    break;

                case 6:
                    _result = _result * 1.725;
                    break;

                case 7:
                    _result = _result * 1.9;
                    break;
            }

            if (rdbResultDjoul.IsChecked == true)
            {
                _result = _result * 4.184;
                _joul = 1;
            }
            else
            {
                _joul = 0;
            }


            OutputWin outputWin = new OutputWin(_result, _joul);
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
                CalculationBmr();
            }
            else
            {
                _errorcount++;
                if (_errorcount % 10 == 0)
                {
                    MessageBox.Show("Попробуйте ввести корректные значения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
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
                    CalculationBmr();
                }
                else
                {
                    _errorcount++;
                    if (_errorcount % 10 == 0)
                    {
                        MessageBox.Show("Попробуйте ввести корректные значения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
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
