using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseConverter
{
    public class Converter
    {
        public static int Base10(string number, int from)
        {
            double answer = 0;
            var places = number.Count();
            for (int i = places-1, j = 0; i >= 0; i--, j++)
            {
                int place;
                var isHex = hexValues.Values.ToList().Contains(number[i].ToString());
                if(isHex)
                {
                    var index = hexValues.Values.ToList().IndexOf(number[i].ToString());
                    place = hexValues.ElementAtOrDefault(index).Key;
                }
                else
                {
                    place = int.Parse(number[i].ToString());
                }
                var powerOfTwo = Math.Pow(from, j);
                answer += place * powerOfTwo; 
            }

            return (int)answer;
        }
        static Dictionary<int, string> hexValues = new Dictionary<int, string>
        { 
            {10, "a"},
            {11, "b"},
            {12, "c"},
            {13, "d"},
            {14, "e"},
            {15, "f"},
            {16, "g"},
            {17, "h"},
            {18, "i"},
            {19, "j"}
        };
        public static string Convert(int number, int to,  int from = 10)
        {
            if (from != 10)
                number = Base10(number.ToString(), from);
            var answer = "";
            while (number != 0)
            {
                var remainder = number % to;
                if (remainder > 9)
                    answer += hexValues[remainder];
                else
                    answer += remainder.ToString();
                number /= to;

            }
            return new(answer.Reverse().ToArray());
        }
        const string _placeholders = "0123456789abcde";
        private static string GetPlaceholders(int @base)
        {
            return _placeholders[..@base];
        }
        private static string Base2(int finalBase, int number, int startBase = 10)
        {
            var placeholders = GetPlaceholders(finalBase);
            string answer = "";
            var onesPosition = 1;
            var incrementor = 0;
            var powerOfBasePosition = onesPosition * finalBase;
            int difference;
            while (number >= powerOfBasePosition)
            {
                incrementor++;
                difference = number - powerOfBasePosition;
                var previousPowerOfBasePosition = powerOfBasePosition;
                powerOfBasePosition *= finalBase;
                if (difference == 0)
                {
                    answer += placeholders[1];
                    
                    while (incrementor > 0)
                    {
                        answer += placeholders[0];
                        incrementor--;
                    }

                    return answer;
                }
                else if (number > previousPowerOfBasePosition && number < powerOfBasePosition)
                {
                   
                    answer += placeholders[1];
                    difference = number - previousPowerOfBasePosition;
                    while (difference != 0 && incrementor > 0)
                    {
                        var beforPrevious = previousPowerOfBasePosition;
                        previousPowerOfBasePosition /= finalBase;
                        if (previousPowerOfBasePosition == difference)
                            answer += placeholders[1];
                        else if (difference < beforPrevious && difference > previousPowerOfBasePosition)
                        {
                            answer += placeholders[1];
                            difference -= previousPowerOfBasePosition;
                        }
                        else
                            answer += placeholders[0];
                        incrementor--;
                    }
                    return answer;
                }

            }
            answer += placeholders[1];
            return answer;
        }
        
    }
}
