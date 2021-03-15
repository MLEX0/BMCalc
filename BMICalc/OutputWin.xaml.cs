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
    /// Логика взаимодействия для OutputWin.xaml
    /// </summary>
    public partial class OutputWin : Window
    {
        private double _bmi;

        public OutputWin(double Growth, double Weight)
        {

            InitializeComponent();


            _bmi = Weight / (Growth * Growth);

            txtBmi.Text = $"Ваш ИМТ равен {Math.Round(_bmi, 2)}";

            if (_bmi < 18.5)
            {
                txtAppeal.Text = "У вас недостаток веса!";
            }
            else if (_bmi > 18.5 && _bmi < 24.9999999999999)
            {
                txtAppeal.Text = "У вас здоровый вес!";
            }
            else if (_bmi > 25 && _bmi < 29.9999999999999)
            {
                txtAppeal.Text = "У вас избыточный вес!";
            }
            else if (_bmi > 30)
            {
                txtAppeal.Text = "У вас ожирение!!";
            }
            if (_bmi >= 100)
            {
                this.Width = 530;
                this.Height = 400;
                txtAppeal.Text = "Номер похоронного бюро по Москве: \n " +
                    "                8 (495) 997-00-73";
            }
        }

        public OutputWin(double result, int joul)
        {
            InitializeComponent();

            this.Width = 670;
            this.Height = 440;

            if (joul == 1)
            {
                txtBmi.Text =  $"Для поддержания веса - {Math.Round(result, 0)} килоджоулей в день";
                txtAppeal.Text = $"Для похудания - {Math.Round(result * 0.8, 0)} килоджоулей в день";
            }
            else
            {
                txtBmi.Text = $"Для поддержания веса - {Math.Round(result, 0)} калорий в день";
                txtAppeal.Text = $"Для похудания - {Math.Round(result * 0.8, 0)} калорий в день";
            }
        }


        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.Close();
            }
        }
    }
}
