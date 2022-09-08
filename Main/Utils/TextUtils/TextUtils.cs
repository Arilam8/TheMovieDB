using System.Collections.Generic;
using System.Text;

namespace Utils.TextUtils
{
    static public class TextUtils
    {
        static public string GetTextMaxLength(string text, int maxLength)
        {
            if (text == null)
                return text;
            if (text.Length > maxLength)
                return text.Substring(0, maxLength - 3) + "...";
            else
                return text;
        }

        static public string GetTextList(List<string> list)
        {
            if (list == null || list.Count <= 0)
                return null;
            string text = string.Empty;
            foreach (string item in list)
            {
                text += item + ", ";
            }
            text = text.Substring(0, text.Length - 2);
            return text;
        }

        static public int GetTextListLength(List<string> list)
        {
            int length = 0;
            foreach (string item in list)
            {
                length += item.Length;
            }
            return length;
        }

        static public int GetSpace(string text, string defaultText, int maxSpace)
        {
            int space = maxSpace;
            if (string.IsNullOrWhiteSpace(text))
                space -= defaultText.Length + 2;
            else
                space -= text.Length;
            return space;
        }

        public static List<int> GetAllIndexOf(string text, string value)
        {
            List<int> indexes = new List<int>();
            if (string.IsNullOrEmpty(value))
                return indexes;
            for (int index = 0; ; index += value.Length)
            {
                index = text.IndexOf(value, index);
                if (index == -1)
                    return indexes;
                indexes.Add(index);
            }
        }

        static public string GetTextWithoutSpace(string text)
        {
            return text.Replace(" ", "");
        }

        static public string GetTextWithoutPunctuation(string text)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (char c in text)
            { 
                if (!char.IsPunctuation(c))
                    stringBuilder.Append(c); 
            }
            return stringBuilder.ToString();
        }
    }
}
