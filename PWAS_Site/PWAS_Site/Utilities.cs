using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using PWAS.Model;
using PWAS.DataAccess.Interfaces;
using System.Web.SessionState;
using System.Text.RegularExpressions;
using System.Text;

namespace PWAS_Site
{
    public enum PrintRunStatus{
        CREATED = 1,
        PRE_PRINTING =7,
        PRINTING = 3,
        FINISHING =4,
        SHIPPING = 5,
        CLOSED = 6
    };
    public enum OrderStatus
    {
        CREATED=1,
        PAID=2,
        PROCESSING=8,
        SHIPPED=9,
        CLOSED=6
    }

    public static class Utilities
    {
        #region String Validation Methods
        public static bool IsValidEmail(this string email)
        {
            Regex regex = new Regex("[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,4}", RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }

        public static bool IsValidPhone(this string phone)
        {
            Regex regex = new Regex("[^0-9]");
            string newPhone = regex.Replace(phone, "");

            return 10 <= newPhone.Length && newPhone.Length <= 11;
        }

        public static bool IsValidState(this string input)
        {
            return input.IsValidLength(2, 2) && input.AllLetters();
        }

        public static bool IsValidLength(this string input, int min, int max)
        {
            return min <= input.Length && input.Length <= max;
        }

        public static bool IsValidZip(this string input)
        {
            return input.IsValidLength(5, 5) && input.AllLetters();
        }

        public static bool IsValidCreditCard(this string input)
        {
            return input.IsValidLength(15, 16) && input.AllDigits();
        }

        public static bool IsValidSecurityCode(this string input)
        {
            return input.IsValidLength(3, 4) && input.AllDigits();
        }

        public static bool IsValidName(this string input)
        {
            Regex regex = new Regex("[a-z ]", RegexOptions.IgnoreCase);
            return regex.IsMatch(input);
        }

        public static bool AllLetters(this string input)
        {
            return input.ToCharArray().All(x => char.IsLetter(x));
        }

        public static bool AllDigits(this string input)
        {
            return input.ToCharArray().All(x => char.IsDigit(x));
        }
        #endregion
    }

    public static class Constants
    {
        internal const string PWAS_SESSION_ID = "PWAS_ID";
        internal const string PWAS_SESSION_NAME = "PWAS_NAME";
    }
}
