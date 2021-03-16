using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMICalc
{
    public static class CalculationClass
    {

        public static double CalculationBMRHarris(double weight, int age, double growth, int gender)
        {
            double _Result;

            if (gender == 1)
            {
                _Result = 66.5 + (13.75 * weight) + (5.003 * growth) - (6.775 * age);

                return _Result;
            }
            else
            {
                _Result = 665.1 + (9.563 * weight) + (1.85 * growth) - (4.676 * age);

                return _Result;
            }
        }

        public static double CalculationBMRMaffin(double weight, int age, double growth, int gender)
        {
            double result;

            if (gender == 1)
            {
                result = (10.00 * weight) + (6.25 * growth) - (5 * age) + 5;

                return result;
            }
            else
            {
                result = (10.00 * weight) + (6.25 * growth) - (5 * age) - 161;

                return result;
            }
        }

    }
}
