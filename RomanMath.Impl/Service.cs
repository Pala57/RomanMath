using System;
using System.Data;

namespace RomanMath.Impl
{
    public static class Service

    {
        /// <summary>
        /// See TODO.txt file for task details.
        /// Do not change contracts: input and output arguments, method name and access modifiers
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>

        public static int Evaluate(string expression)
        {
            if (string.IsNullOrEmpty(expression))
            {
                throw new ArgumentException();
            }
            var dopustSim = new[] { ' ', '+', '-', '*', 'M', 'I', 'V', 'X', 'L', 'C', 'D', 'M' };
            //throw new NotImplementedException();  


            foreach (var e in expression)
            {
                var contains = false;
                foreach (var n in dopustSim)
                {
                    if (e == n)
                    {
                        contains = true;
                    }
                }

                if (contains == false)
                {
                    throw new ArgumentException(expression);
                }
            }

            var b = expression;
            var c = "";
 
            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] != '+' && expression[i] != '-' && expression[i] != '*')
                {
                 
                    c += expression[i];

                    if (i == expression.Length - 1)
                    {

                        var f = ConvertNumerals(c);
                        b = ReplaceFirstOccurrence(b, c, f.ToString());
                       
                    }
                }
                else
                {
                    var f = ConvertNumerals(c);
                    b = ReplaceFirstOccurrence(b, c, f.ToString());
               
                    c = "";
                }

            }

            string value = new DataTable().Compute(b, null).ToString();

            return Int32.Parse(value);
        }

        public static string ReplaceFirstOccurrence(string Source, string Find, string Replace)
        {
            int Place = Source.IndexOf(Find);
            string result = Source.Remove(Place, Find.Length).Insert(Place, Replace);
            return result;
        }


        public static int ConvertNumerals(string roman)
        {
            int outVal = 0;
            roman = roman.ToUpper();
            for (int i = 0; i < roman.Length; i++)
            {
                char character = roman[i];
                if (i != roman.Length - 1 && GetRomanValue(roman[i]) < GetRomanValue(roman[i + 1]))
                {

                    outVal += GetRomanValue(roman[i + 1]) - GetRomanValue(roman[i]);
                    i++;
                    continue;
                }

                else
                {
                    outVal += GetRomanValue(roman[i]);
                }

            }
            return outVal;
        }
        public static int GetRomanValue(char val)
        {
            switch (val)
            {
                case 'I':
                    return 1;
                case 'V':
                    return 5;
                case 'X':
                    return 10;
                case 'L':
                    return 50;
                case 'C':
                    return 100;
                case 'D':
                    return 500;
                case 'M':
                    return 1000;
                default:
                    return 0;
            }
        }



    }
}

		


	

