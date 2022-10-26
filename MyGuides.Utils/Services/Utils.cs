using System.Text.RegularExpressions;

namespace MyGuides.Utils
{
    public static class Utils
    {
        public static bool IsNumeric(string param)
        {
            if (Regex.IsMatch(param, @"^\d+$"))
                return true;
            else
                return false;
        }

        public static string Capitalize(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            string realName = string.Empty;
            input = input.ToLower();
            List<string> word = input.Split(' ').ToList();

            if (word.Count() > 1)
            {
                foreach (var item in word)
                {
                    if (IsNumeric(item))
                    {
                        realName += item + " ";
                    }
                    else
                    {
                        realName += char.ToUpper(item[0]) + item.Substring(1) + " ";
                    }
                }
            }
            else
                realName = char.ToUpper(input[0]) + input.Substring(1);

            realName = realName.Trim();
            return realName;
        }
    }
}
