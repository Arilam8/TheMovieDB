using System;

namespace Utils.ParserUtils
{
    static public class ParserUtils
    {
        static public int ParseInt(string number)
        {
            int numberInt;
            if (Int32.TryParse(number, out numberInt))
                return numberInt;
            else
                return -1;
        }

        static public float ParseFloat(string number)
        {
            float numberFloat;
            if (float.TryParse(number, out numberFloat))
                return numberFloat;
            else
                return -1;
        }

        static public double ParseDouble(string number)
        {
            double numberDouble;
            if (double.TryParse(number, out numberDouble))
                return numberDouble;
            else
                return -1;
        }

        static public DateTime ParseDate(string date)
        {
            DateTime dateTime;
            if (DateTime.TryParse(date, out dateTime))
                return dateTime;
            else
                return (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
        }
    }
}
