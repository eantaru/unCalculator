using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Utils
{
    public static string inverseString(string s)
    {
        //manually inverse
        char[] array = new char[s.Length];
        int forward = 0;
        for (int i = s.Length - 1; i >= 0; i--)
        {
            array[forward++] = s[i];
        }

        return new string(array);
    }

    public static bool isOnlyNumeric(String numerics)
    {
        Regex regex = new Regex(@"^-?\d*(\.\d+)?$");

        return regex.IsMatch(numerics);
    }

    public static String removeUnnecessaryZeroes(String decimals)
    {
        if (decimals == null || decimals.Equals("")) return "";

        String s = Regex.Replace("." + decimals, @"(?<=\.\d+?)0+(?=\D|$)", String.Empty);
        return s.Substring(1, s.Length - 1);
    }

    public static String replaceNecessaryZeroes(string decimals)
    {
        if (decimals == null || decimals.Equals("")) return "";

        String s = "";
        for (int n = 0; n < decimals.Length; n++)
        {
            char ch = decimals[n];
            if (ch == '0')
            {
                s += "zero ";
            }
            else
            {
                return " " +s;
            }
        }

        return s;
    }

    public static IEnumerable<string> splitEachCharacters(string s, int n)
    {
        //manually loop
        for (int i = 0; i < s.Length; i += n)
            yield return s.Substring(i, Math.Min(n, s.Length - i));
    }


    public static IEnumerable<string> splitEachCharactersFromRight(string s, int n)
    {
        //manually loop
        for (int i = 0; i < s.Length; i += n)
            yield return s.Substring(Math.Max(0, s.Length - i - n), Math.Min(n, s.Length - i));
    }

    /**
    public static List<string> splitEachCharacters(string s, int n)
    {
        string pattern = @"(?<=\G.{"+ n +"})";
        return new List<string>(Regex.Split(s, pattern));
    }
     */

    public static List<uint> transformToThousand(ulong numeric, uint division)
    {
        List<uint> res = new List<uint>();
        while (numeric > 0)
        {
            //read thousand(s), hundred(s), ten(s)
            //uint d = Convert.ToUInt32(division);
            ulong val = numeric % division;
            numeric /= division;

            res.Add(Convert.ToUInt32(val));
        }

        return res;
    }
}