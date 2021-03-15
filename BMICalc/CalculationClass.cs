using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMICalc
{
    public static class CalculationClass
    {

        public static double Calculation_BMR_Harris(double _Weight, double _Age, double _Growth, int _Gender)
        {
            double _Result;

            if (_Gender == 1)
            {
                _Result = 66.5 + (13.75 * _Weight) + (5.003 * _Growth) - (6.775 * _Age);

                return _Result;
            }
            else
            {
                _Result = 665.1 + (9.563 * _Weight) + (1.85 * _Growth) - (4.676 * _Age);

                return _Result;
            }
        }

        public static double Calculation_BMR_Maffin(double _Weight, double _Age, double _Growth, int _Gender)
        {
            double _Result;

            if (_Gender == 1)
            {
                _Result = (10.00 * _Weight) + (6.25 * _Growth) - (5 * _Age) + 5;

                return _Result;
            }
            else
            {
                _Result = (10.00 * _Weight) + (6.25 * _Growth) - (5 * _Age) - 161;

                return _Result;
            }
        }

    }
}
