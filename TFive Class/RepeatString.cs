using System;
using System.Linq;
using System.Text;

namespace TFive_Class
{
    public class RepeatString
    {
        static string RepeatForLoop(string s, int n)
        {
            var result = s;
            var builder = new StringBuilder();
            for (var i = 0; i < n - 1; i++)
            {
                //result += s;
                builder.Append(s);
            }

            return result;
        }

        static string RepeatPadLeft(string s, int n)
        {
            return "".PadLeft(n, 'X').Replace("X", s);
        }

        static string RepeatReplace(string s, int n)
        {
            return new string('X', n).Replace("X", s);
        }

        static string RepeatConcat(string s, int n)
        {
            return string.Concat(Enumerable.Repeat(s, n));
        }

        static string RepeatStringBuilderInsert(string s, int n)
        {
            return new StringBuilder(s.Length * n)
                .Insert(0, s, n)
                .ToString();
        }

        //public static string RepeatStringBuilderAppend(string s, int n)
        //{
        //    return new StringBuilder(s.Length * n)
        //                .AppendFormat(s, new string[n + 1]) 
        //                //.AppendJoin(s, new string[n + 1])
        //                .ToString();
        //}

        //new
        //Repeat_String.RepeatChars(text, num);
        //Repeat_String.RepeatWords(text, num);
        public static string RepeatStringBuilderInsertChars(string s, int n)
        {
            return new StringBuilder(s.Length + n).Insert(0, s, n).ToString();
        }

        public static string RepeatStringBuilderInsertWords(string s, int n)
        {
            return new StringBuilder(s.Length * n).Insert(0, s, n).ToString();
        }

        public static string RepeatChars(string input, int count)
        {
            var dest = new char[input.Length + count];
            for (int i = 0; i < dest.Length; i++)
            {
                dest[i] = input[i % input.Length];
            }
            return new string(dest);
        }

        public static string RepeatWords(string input, int count)
        {
            var dest = new char[input.Length * count];
            for (int i = 0; i < dest.Length; i++)
            {
                dest[i] = input[i % input.Length];
            }
            return new string(dest);
        }
    }
}
