using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook
{
    public class Validation
    {
        public bool Required { get; set; }
        public int MinLength { get; set; }
        public int MaxLength { get; set; }
        public char[] ValidSymbols { get; set; }

        public Validation(bool required, int minLength, int maxLength, char[] validSymbols)
        {
            Required = required;
            MinLength = minLength;
            MaxLength = maxLength;
            ValidSymbols = validSymbols;
        }

        public bool TryValidate(string v, out string result)
        {
            if (String.IsNullOrWhiteSpace(v) || String.IsNullOrEmpty(v))
            {
                if (Required)
                {
                    result = "Это поле является обязательным!";
                    return false;
                }
                else
                {
                    result = null;
                    return true;
                }
            }

            if (v.Length < MinLength)
            {
                result = $"Минимальная длина: {MinLength}!";
                return false;
            }

            if (v.Length > MaxLength)
            {
                result = $"Максимальная длина: {MaxLength}!";
                return false;
            }

            foreach (var item in v)
                if (!ValidSymbols.Contains(item))
                {
                    result = $"Используйте только: {new string(ValidSymbols)}!";
                    return false;
                }

            result = null;
            return true;
        }
    }
}
