using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Data;
using Newtonsoft.Json.Linq;

namespace HNUiMap.core
{
    public static class StringManipulation
    {
        /// <summary>
        /// This method will convert your string/phrase into Title Case
        /// Sample input: red fox jump
        /// Output: Red Fox Jump
        /// </summary>
        /// <param name="stringInput"></param>
        /// <returns></returns>
        public static string ToTitleCase(this string stringInput) 
        {
            try
            {
                string stringOutput;
                stringOutput = stringInput.ToLower();
                stringOutput = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(stringInput);
                return stringOutput;
            }
            catch { return stringInput; }
        }

        /// <summary>
        /// This method will capitalize the first letter of the string input
        /// Sample input: hello world
        /// Output: Hello world
        /// </summary>
        /// <param name="stringInput"></param>
        /// <returns></returns>
        public static string ToSenteceCase(this string stringInput) 
        {
            try
            {
                char[] stringInputInChar = stringInput.ToCharArray();
                if (stringInput.Length > 0)
                {
                    stringInputInChar[0] = char.ToUpper(stringInputInChar[0]);
                    return new string(stringInputInChar);
                }
                return stringInput;
            }
            catch { return stringInput; }
        }

        /// <summary>
        /// This method will return the proper money/currency case.
        /// Sample input: 10000292010
        /// Output: 10,000,292,010.00
        /// 
        /// Note: Data Type to send is in string format.
        /// </summary>
        /// <param name="numberInString"></param>
        /// <returns></returns>

        public static string ToCurrencyCase(this string numberInString) 
        {
            try { return Convert.ToDouble(numberInString).ToString("N2");}
            catch { return numberInString; }
        }


        /// <summary>
        /// This method will return the proper money/currency case.
        /// Sample input: 10000292010
        /// Output: 10,000,292,010
        /// 
        /// Note: Data Type to send is in string format.
        /// </summary>
        /// <param name="numberInString"></param>
        /// <returns></returns>

        public static string ToNumberWithComma(this string numberInString)
        {
            try { return Convert.ToDouble(numberInString).ToString("N0"); }
            catch { return numberInString; }
        }

        /// <summary>
        /// This method will return wordCount number of word in the sentence input
        /// Sample input: Hello World, Welcome to programming
        /// Output: 5
        /// </summary>
        /// <param name="stringInput"></param>
        /// <returns></returns>
        public static int WordCount(this string stringInput) 
        {
            try 
            {
                if(stringInput.Length > 0)
                {
                    int wordCounter = 0;
                    var matchesByListedChars = Regex.Matches(stringInput,
                    @"[^\s.?,]+", RegexOptions.CultureInvariant | RegexOptions.Multiline
                    | RegexOptions.IgnoreCase);
                    wordCounter = matchesByListedChars.Count;
                    return wordCounter;
                }
                return 0;
            }
            catch { return 0; }
        }

        /// <summary>
        /// This method will return numbers= in words form the integer input
        /// Sample input: 100
        /// Output: One Hundred
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string NumberToWords(this int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }

        public static DataTable JsonStringToDatatable(string json)
        {
            var result = new DataTable();
            var jArray = JArray.Parse(json);
            //Initialize the columns, If you know the row type, replace this   
            foreach (var row in jArray)
            {
                foreach (var jToken in row)
                {
                    if (!(jToken is JProperty jproperty)) continue;
                    if (result.Columns[jproperty.Name] == null)
                        result.Columns.Add(jproperty.Name, typeof(string));
                }
            }
            foreach (var row in jArray)
            {
                var datarow = result.NewRow();
                foreach (var jToken in row)
                {
                    if (!(jToken is JProperty jProperty)) continue;
                    datarow[jProperty.Name] = jProperty.Value.ToString();
                }
                result.Rows.Add(datarow);
            }

            return result;
        }

        public static string ToMySQLDateTimeFormat(this DateTime date)
        {
            string year = date.Year.ToString();
            string month = date.Month.ToString("00");
            string day = date.Day.ToString("00");

            string hour = date.Hour.ToString("00");
            string minute = date.Minute.ToString("00");
            string second = date.Second.ToString("00");

            return string.Concat(year, "-", month, "-", day, " ", hour, ":", minute, ":", second);
        }

        public static string ToMySQLDateFormat(this DateTime date)
        {
            string year = date.Year.ToString();
            string month = date.Month.ToString("00");
            string day = date.Day.ToString("00");

            return string.Concat(year, "-", month, "-", day);
        }
    }
}
