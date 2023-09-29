using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS.Framework
{
    public class Validation
    {



        public static double  ConvertToDouble(string value, string error) 
        {
            if(!String.IsNullOrEmpty(value)){


                double result = 0.00;
                if (double.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out result))
                {
                    return result;
                }
                else
                {
                    MessageBox.Show("Invalid "+error);
                    throw new Exception();
                } 
            }
            else 
            {
                MessageBox.Show(error+ " can't be empty");
                throw new Exception();
            }
           
        }
        public static int ConvertToInt(string value, string errorMessage)
        {

            int result = 0;
            if (int.TryParse(value, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out result))
            {
                return result;
            }
            else
            {
                MessageBox.Show(errorMessage);
                throw new Exception();
            }

        }

        public static bool IsStringInvalid(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                return false;

            return true;
        }

        public static bool IsIntValid(string value)
        {
            int i;
            return Int32.TryParse(value, out i);
        }

        public static bool IsFloatValid(string value)
        {
            try
            {
                float.Parse(value);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
