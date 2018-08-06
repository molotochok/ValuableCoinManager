using System;

namespace ValuableCoins
{
    static class TypeParser
    {

        // Parse values
        public static int ParseInt(string str)
        {
            int number = 0;
            int.TryParse(str, out number);
            return number;
        }
        public static float ParseFloat(string str)
        {
            float number = 0f;
            float.TryParse(str, out number);
            return number;
        }
        public static DateTime ParseDate(string str)
        {
            // Parse str to change ukrainian words to english
            string oldMonth = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsLetter(str[i]))
                {
                    // Checks if char equals i (english) and store in oldMonth i (ukrainian)
                    if (str[i].Equals('i'))
                    {
                        str = str.Replace(str[i], 'і');
                    }
                    oldMonth += str[i];
                }
            }
            oldMonth = oldMonth.ToLower();

            string newMonth = "";
            switch (oldMonth)
            {
                case "січня": newMonth = "january"; break;
                case "лютого": newMonth = "february"; break;
                case "березня": newMonth = "march"; break;
                case "квітня": newMonth = "april"; break;
                case "травня": newMonth = "may"; break;
                case "червня": newMonth = "june"; break;
                case "липня": newMonth = "july"; break;
                case "серпня": newMonth = "august"; break;
                case "вересня": newMonth = "september"; break;
                case "жовтня": newMonth = "october"; break;
                case "листопада": newMonth = "november"; break;
                case "грудня": newMonth = "december"; break;
                default: break;
            }
            str = str.Replace(oldMonth, newMonth);
            DateTime dateTime = new DateTime();

            DateTime.TryParse(str, out dateTime);

            return dateTime;
        }
    }
}
