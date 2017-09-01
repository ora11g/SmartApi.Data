using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBed.Service
{
    public class Utils
    {

        public static DateTime DateTimeValidation(string paramValue, string paramName)
        {
            if (string.IsNullOrWhiteSpace(paramValue))
            {
                throw new ArgumentException("DateTime string can not be null or empty.", paramName);
            }

            DateTime result;

            if (!DateTime.TryParse(paramValue, out result))
            {
                throw new ArgumentOutOfRangeException(paramName, string.Format("String '{0}' was not recognized as a valid DateTime.", paramValue));
            }

            return result;
        }

        public static void StringValidation(string paramValue, string paramName)
        {
            if (string.IsNullOrWhiteSpace(paramValue))
            {
                throw new ArgumentException(string.Format("{0} can not be null or empty.", paramName), paramName);
            }
        }

        public static int IdentifierValidation(string paramValue, string paramName)
        {
            int result;

            if (string.IsNullOrWhiteSpace(paramValue))
            {
                throw new ArgumentException(string.Format("{0} can not be null or empty.", paramName), paramName);
            }

            if (int.TryParse(paramValue, out result))
            {
                if (result < 0)
                    throw new ArgumentOutOfRangeException(paramName, string.Format("'{0}' is not a valid positive integer.", paramValue));
                return result;
            }

            throw new ArgumentException(string.Format("'{0}' is not a valid {1}.", paramValue, paramName), paramName);
        }
    }
}
