using System;

class Mapper
{
    public static String prefixUnits(uint n)
    {
        if (n == 1) return "un";
        else if (n == 2) return "duo";
        else if (n == 3) return "tre";
        else if (n == 4) return "quanttuor";
        else if (n == 5) return "quinqua";
        else if (n == 6) return "se";
        else if (n == 7) return "septe";
        else if (n == 8) return "octo";
        else if (n == 9) return "nove";

        return "";
    }

    public static String prefixTens(uint n)
    {
        if (n == 1) return "deci";
        else if (n == 2) return "viginti";
        else if (n == 3) return "triginta";
        else if (n == 4) return "quadraginta";
        else if (n == 5) return "quinquaginta";
        else if (n == 6) return "sexaginta";
        else if (n == 7) return "septuaginta";
        else if (n == 8) return "octoginta";
        else if (n == 9) return "nonaginta";

        return "";
    }

    public static String suffix(String prefix)
    {
        if(prefix == null || prefix.Equals("")) {
            return "";
        }

        int endIndex = prefix.Length - 1;
        String last = prefix.Substring(endIndex, 1);

        //Console.WriteLine("prefix = {0}, endIndex = {1}, last = {2}", prefix, endIndex, last);

        if (last.Equals("i")) return prefix + "llion";
        else if (last.Equals("a")) return prefix.Substring(0, endIndex) + "illion";

        return "illion";
    }

    public static String prefixHundreds(uint n)
    {
        if (n == 1) return "un";
        else if (n == 2) return "duo";
        else if (n == 3) return "tre";
        else if (n == 4) return "quanttuor";
        else if (n == 5) return "quinqua";
        else if (n == 6) return "se";
        else if (n == 7) return "septe";
        else if (n == 8) return "octo";
        else if (n == 9) return "nove";

        return "";
    }

    public static String multiply(uint n)
    {
        if (n / 3 == 1) return "thousand";
        else if (n / 3 == 2) return "million";
        else if (n / 3 == 3) return "billion";
        else if (n / 3 == 4) return "trillion";
        else if (n / 3 == 5) return "quadrillion";
        else if (n / 3 == 6) return "quintillion";
        else if (n / 3 == 7) return "sextillion";
        else if (n / 3 == 8) return "septillion";
        else if (n / 3 == 9) return "octillion";
        else if (n / 3 == 10) return "nonillion";
        
        //10^33
        n = n / 3;
        if (n >= 11)
        {
            String sfx = "";

            uint x = (n - 11);
            
            uint y = x % 10;

            if(y > 0) {
                sfx = prefixUnits(y);
            }

            uint grece = (uint)((int)(x / 10)) + 1;
            String prefix = prefixTens(grece);
            //Console.WriteLine("grece = {0}, prefix = {1}", grece, prefix);
            sfx += suffix(prefix);
            
            return sfx;
        }

        return "";
    }

    public static String tensMapper(uint tens)
    {
        if (tens == 19) return "nineteen";
        else if (tens == 18) return "eighteen";
        else if (tens == 17) return "seventeen";
        else if (tens == 16) return "sixteen";
        else if (tens == 15) return "fifteen";
        else if (tens == 14) return "fourteen";
        else if (tens == 13) return "thirteen";
        else if (tens == 12) return "twelve";
        else if (tens == 11) return "eleven";
        else if (tens == 10) return "ten";

        return "";
    }

    public static String tensTyMapper(uint tens)
    {
        if (tens == 9) return "ninety";
        else if (tens == 8) return "eighty";
        else if (tens == 7) return "seventy";
        else if (tens == 6) return "sixty";
        else if (tens == 5) return "fifty";
        else if (tens == 4) return "forty";
        else if (tens == 3) return "thirty";
        else if (tens == 2) return "twenty";

        return "";
    }

    public static String unitMapper(uint unit)
    {
        if (unit == 9) return "nine";
        else if (unit == 8) return "eight";
        else if (unit == 7) return "seven";
        else if (unit == 6) return "six";
        else if (unit == 5) return "five";
        else if (unit == 4) return "four";
        else if (unit == 3) return "three";
        else if (unit == 2) return "two";
        else if (unit == 1) return "one";

        return "";
    }
}
