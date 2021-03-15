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

namespace BMICalc
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Calculation();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Calculation();
            }

            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        private void Calculation()
        {
            if (boxGrowth.Text != "" && boxWeight.Text != "" && (Convert.ToDouble(boxGrowth.Text) != 0 && Convert.ToDouble(boxWeight.Text) != 0))
            {
                double G = Convert.ToDouble(boxGrowth.Text);
                double W = Convert.ToDouble(boxWeight.Text);

                G = G / 100;

                OutputWin outputWin = new OutputWin(G, W);
                this.Hide();
                outputWin.ShowDialog();
                this.Close();
            }
        }

        private void boxGrowth_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789".IndexOf(e.Text) < 0;
        }

        private void boxWeight_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789,".IndexOf(e.Text) < 0;
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

        private void boxWeight_GotFocus(object sender, RoutedEventArgs e)
        {
            if (boxWeight.Text == "0,00")
            {
                boxWeight.Text = "";
            }
        }

        private void boxWeight_LostFocus(object sender, RoutedEventArgs e)
        {
            if (boxWeight.Text == "")
            {
                boxWeight.Text = "0,00";
            }
        }
    }
}
