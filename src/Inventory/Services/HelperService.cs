using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Services
{
    public static class HelperService
    {
        public static int IncrementX(ref int X,int by)
        {
            X += by;
            return X;
        }
        public static string getContinentFromCountry(string country)
        {
            string continent;
            if (country == "CN" || country == "HK")
                continent = "ASIA";
            else if (country == "NL")
                continent = "EU";
            else if (country == "US")
                continent = "North America";
            else
                continent = "Others";
            return continent;
        }
        public static string getContinentColor(int i)
        {
            string color = "";
            if (i == 1)
                color = "#3F3F3F";
            else if (i == 2)
                color = "#939393";
            else if (i == 3)
                color = "#f1f1f1";
            else
                color = "#f6f6f6";
            return color;
        }

    }
}
