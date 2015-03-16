using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Text.RegularExpressions;


    /// <summary>
    /// Summary description for Validation
    /// </summary>
    public class Validation
    {
        
        /// <summary>
        /// Validates the required text field.
        /// </summary>
        /// <param name="txtBox">The Text string</param>
        /// <returns></returns>
        public static bool ValidateRequiredTextField(string txtBoxString)
        {
            if (txtBoxString == "")
                return false;
            else
                return true;
        }
        /// <summary>
        /// Validates integer number.
        /// </summary>
        /// <param name="Number">The number.</param>
        /// <returns></returns>
        public static bool ValidateInt(string Number)
        {
            int Value = 0;
            if (Number != "")
            {
                if (int.TryParse(Number, out Value) != true)
                {
                    return false;
                }
                else
                {
                    if (int.Parse(Number.Trim()) < 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            else return true;
        }


        /// <summary>
        /// Validates the email.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        public static bool ValidateEmail(string Email)
        {
            Regex EmailCheck = new Regex(@"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
         + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
           + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
           + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$");
            return EmailCheck.IsMatch(Email);

        }
        /// <summary>
        /// Validates float number.
        /// </summary>
        /// <param name="Number">The number.</param>
        /// <returns></returns>
        public static bool ValidateFloat(string Number)
        {
            float Value = 0;
            if (Number != "")
            {
                if (float.TryParse(Number, out Value) != true)
                {
                    return false;
                }
                else
                {
                    if (float.Parse(Number.Trim()) < 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            else return true;
        }

        /// <summary>
        /// Validates decimal number.
        /// </summary>
        /// <param name="Number">The number.</param>
        /// <returns></returns>
        public static bool ValidateDecimal(string Number)
        {
            decimal Value = 0;
            if (Number != "")
            {
                if (decimal.TryParse(Number, out Value) != true)
                {
                    return false;
                }
                else
                {
                    if (decimal.Parse(Number.Trim()) < 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            else return true;
        }

        /// <summary>
        /// Validates the date.
        /// </summary>
        /// <param name="Date">The date.</param>
        /// <returns></returns>
        public static bool ValidateDate(String Date)
        {

            DateTime Value;
            if (Date != "")
            {
                if (DateTime.TryParse(Date, out Value) != true)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else return true;

        }

        /// <summary>
        /// Function to Check for if the Name has only letters, spaces, numbers, underscore and apostrophes.
        /// </summary>
        /// <param name="strToCheck"></param>
        /// <returns></returns>
        public static bool ValidateName(String strToCheck)
        {
            Regex objAlphaNumericPattern = new Regex("[^a-zA-Z0-9'_ ]");
            return !objAlphaNumericPattern.IsMatch(strToCheck);
        }


        /// <summary>
        /// Function to Check for if User Name has only letters, numbers.
        /// </summary>
        /// <param name="strToCheck"></param>
        /// <returns></returns>
        public static bool ValidateUserName(String strToCheck)
        {
            Regex objAlphaNumericPattern = new Regex("[^a-zA-Z0-9]");
            return !objAlphaNumericPattern.IsMatch(strToCheck);
        }

        /// <summary>
        /// Validates the day time.
        /// </summary>
        /// <param name="dayTime">The day time.</param>
        /// <returns></returns>
        public static bool ValidateDayTime(string dayTime)
        {
            Regex objAlphaNumericPattern = new Regex("^([0]{1}[1-9]|[1-9]{1}|[1]{1}[0-2]{1}):([0-5]{1}[0-9]{1}|[0-9]{1})$");
            return objAlphaNumericPattern.IsMatch(dayTime);
        }

        public static bool ValidateMobileNumber(string mobileNumber)
        { 
             Regex objAlphaNumericPattern = new Regex(@"^((\+)?(\d{2}[-]))?(\d{10}){1}?$");
            return objAlphaNumericPattern.IsMatch(mobileNumber);
        }

      
    }
