using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace unCalculator {
    class App {

        enum Division
        {
            Thousand = 1000,
            Hundred = 100,
            Ten = 10
        }

        const int maxDigits = 18;//for safety max ulong

        static void Main(string[] args) {

            if (args != null && args.Length > 0)
            {
                string paramOne = args[0];
                if (paramOne.Equals("file"))
                {
                    string paramTwo = args[1];
                    findFileByPath(paramTwo);
                }
                else if (paramOne.Equals("test"))
                {
                    string paramTwo = args[1];
                    testCase(paramTwo);
                }
            }
            else
            {
                testCase("300");
                testCase("3500");
                testCase("3004");   
            }
        }

        private static void findFileByPath(string path)
        {
            //String path = @"E:\MITRAIS\WORKSPACE\DotNet\unCalculator\test-case.txt";
            if (File.Exists(path))
            {
                string[] cases = File.ReadAllLines(path);
                foreach (string caze in cases)
                {
                    testCase(caze);
                }
            }
            else
            {
                Console.WriteLine("file not found! ({0})", path);
            }
        }

        private static void testCase(string samples)
        {
            if (Utils.isOnlyNumeric(samples))
            {
                Console.WriteLine("source: {0}", samples);

                List<string> sources = samples.Split('.').ToList<string>();

                List<string> left = new List<string>();
                
                List<string> right = new List<string>();

                String zeroes = "";

                int n = 1;

                foreach (string s in sources)
                {
                    if (n == 1)
                    {
                        left.Add(" dollars");
                        solution(s, left, false);
                    }
                    else if (n == 2)
                    {
                        string cents = Utils.removeUnnecessaryZeroes(s);

                        zeroes = Utils.replaceNecessaryZeroes(cents);

                        right.Add(" cents");

                        solution(cents, right, true);

                        if (left.Count() > 1 && right.Count() > 1)
                        {
                            right.Add(" and" + zeroes);
                        }
                    }
                    n++;
                }

                //final
                Console.WriteLine("Result:");
                left.Reverse();
                foreach (string s in left)
                {
                    Console.Write("{0}", s);
                }

                if (right.Count() > 1)
                {
                    right.Reverse();
                    foreach (string s in right)
                    {
                        Console.Write("{0}", s);
                    }
                }
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("{0} is not numeric, source shall only numeric", samples);
            }
        }

        private static void solution(String text, List<string> collections, bool cents)
        {
            IEnumerable<string> numbers = Utils.splitEachCharactersFromRight(text, maxDigits);

            uint start = 0;

            foreach (string number in numbers)
            {
                uint multiply = (start++) * maxDigits;

                //Console.WriteLine("multiply: {0}", multiply);

                if (!number.Trim().Equals(""))
                {
                    ulong value = Convert.ToUInt64(number.Trim());

                    //Console.WriteLine("origin {0}", value);

                    List<uint> thousands = transformToThousand(value, Division.Thousand);
                    foreach (uint t in thousands)
                    {
                        string readable = "";

                        uint hundred = t / Convert.ToUInt32(Division.Hundred);

                        uint ten = (t % Convert.ToUInt32(Division.Hundred))
                            / Convert.ToUInt32(Division.Ten);

                        uint unit = t % Convert.ToUInt32(Division.Ten);

                        readable = transformToString(unit, ten, hundred);

                        //if (unit > 0 || ten > 0 || hundred > 0)
                        if (unit + ten + hundred > 0) readable += " " + Mapper.multiply(multiply);

                        multiply += 3;

                        if (!readable.Trim().Equals(""))
                        {
                            collections.Add(readable);
                        }
                    }
                }
            }

            if (collections.Count() > 0)
            {
                //if (cents) collections.Add(" cents");
                //else collections.Add(" dolars");
            }
        }

        private static String transformToString(uint unit, uint ten, uint hundred)
        {
            //Console.WriteLine("Log unit:{0}, ten:{1}, hundred:{2}", unit, ten, hundred);
            string res = "";
            if (hundred > 0) res += Mapper.unitMapper(hundred) + " hundred";

            uint tens = ten * 10 + unit;

            if (tens > 9 && tens < 20) res += " " + Mapper.tensMapper(tens);
            else if (ten > 0) res += " " + Mapper.tensTyMapper(ten);

            if (unit > 0 && (tens >= 20 || tens == unit))
            {
                if (!Mapper.unitMapper(unit).Equals(""))
                {
                    res += " " + Mapper.unitMapper(unit);
                }
            }

            return res;
        }


        private static List<uint> transformToThousand(ulong numeric, Division division)
        {
            return Utils.transformToThousand(numeric, Convert.ToUInt32(division));
        }

    }
}
