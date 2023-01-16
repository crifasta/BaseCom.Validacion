using System;
using System.Text.RegularExpressions;

namespace BaseCom.Validacion
{
     public static class  ExtValString
    {



        /// <summary>
        /// indica si una cadena tiene un numero
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static bool HasNumber(this string x)
        {
            Regex regularEx = new Regex("[0-9]");
            if (regularEx.IsMatch(x))
                return true;
            return false;
        }

        public static bool IsNull(this string value)
        {
            bool bRet = true;

            if (!String.IsNullOrEmpty(value))
            {
                if (value != null)
                {
                    if (value.Length > 0)
                    {
                        bRet = false;

                    }

                }
            }

            return bRet;

        }

        public static bool IsNotNull(this string value)
        {
            bool bRet = false;

            if (value != null)
            {
                if (value.Length > 0)
                {
                    bRet = true;

                }

            }

            return bRet;

        }

        public static bool EsAlfabetico(this string x)
        {
            Regex patronAlfabetico = new Regex("[^a-zA-Z]");
            return !patronAlfabetico.IsMatch(x);
        }

        public static bool IsAlphanumeric(this string x)
        {
            Regex patronAlfanumerico = new Regex("[^a-zA-Z0-9]");
            return !patronAlfanumerico.IsMatch(x);
        }

        public static bool IsEmail(this string s)
        {
            return new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,6}$").IsMatch(s);
        }


        /// <summary>
        ///
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool ValidURL(this string url)
        {
            string strRegex = "^(https?://)"
        + "?(([0-9a-z_!~*'().&=+$%-]+: )?[0-9a-z_!~*'().&=+$%-]+@)?" //user@
        + @"(([0-9]{1,3}\.){3}[0-9]{1,3}" // IP- 199.194.52.184
        + "|" // allows either IP or domain
        + @"([0-9a-z_!~*'()-]+\.)*" // tertiary domain(s)- www.
        + @"([0-9a-z][0-9a-z-]{0,61})?[0-9a-z]" // second level domain
        + @"(\.[a-z]{2,6})?)" // first level domain- .com or .museum is optional
        + "(:[0-9]{1,5})?" // port number- :80
        + "((/?)|" // a slash isn't required if there is no file name
        + "(/[0-9a-z_!~*'().;?:@&=+$,%#-]+)+/?)$";
            return new Regex(strRegex).IsMatch(url);
        }



    }
}
