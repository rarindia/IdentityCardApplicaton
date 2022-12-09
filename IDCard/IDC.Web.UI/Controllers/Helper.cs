using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;

namespace IDC.Web.UI
{
    public static class Helper
    {

        public static bool ValidateDate()
        {
            string date = ConfigurationManager.AppSettings["Validity"].DecodeBase64();
            return DateTime.Now <= Convert.ToDateTime(date);
        }

        public static bool ShowExpirationMessage()
        {
            int numberOfDays = NumberOfDays();
            int a = Convert.ToInt32(ConfigurationManager.AppSettings["ValidityExpired"]);
            return numberOfDays <= a;
        }

        public static int NumberOfDays()
        {
            DateTime expirationDate = Convert.ToDateTime(ConfigurationManager.AppSettings["Validity"].DecodeBase64());
            DateTime currentDate = DateTime.Now;
            var numberOfDays = (expirationDate - currentDate).Days;
            return numberOfDays;
        }

        public static string EncodeBase64(this string value)
        {
            var valueBytes = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(valueBytes);
        }

        public static string DecodeBase64(this string value)
        {
            var valueBytes = System.Convert.FromBase64String(value);
            return Encoding.UTF8.GetString(valueBytes);
        }
    }
}