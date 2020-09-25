using System;
using System.Text;

namespace ABDT_hw
{
    public class Comperessor
    {
        public string Compress(string str) {
            var size = CountCompression(str);
            if (size >= str.Length) {
                return str;
            }

            var resultString = new StringBuilder();
            var last = str[0];
            var count = 1;
            for (var i = 1; i < str.Length; i++)	{
                if (str[i] == last) {
                    count++;
                } else {
                    resultString.Append(last);
                    resultString.Append(count);
                    last = str[i];
                    count = 1;
                }
            }

            resultString.Append(last);
            resultString.Append(count);
            return resultString.ToString();
        }

        private static int CountCompression(string str) {
            var last = str[0];
            var size = 0;
            var count = 1;
            for (var i = 1; i < str.Length; i++) {
                if (str[i] == last) {
                    count++;
                } else	{
                    last = str[i];
                    size += 1 + count.ToString().Length;
                    count = 0;
                }
            }
            size += 1 + count.ToString().Length;
            return size;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var compressor = new Comperessor();
            const string source = "aabcccccaaa";
            Console.WriteLine(compressor.Compress(source));
        }
    }
}