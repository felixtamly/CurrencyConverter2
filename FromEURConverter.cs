using System;
using System.Collections.Generic;

namespace CurrencyConverter2
{
    public class FromEURConverter
    {
        readonly List<Currency> CurrencyList;
        public FromEURConverter(List<Currency> CurrencyList)
        {
            this.CurrencyList = CurrencyList;
        }
        public double ConvertFromEUR(string Name, double eur)
        {
            RateFinder RateFinder = new RateFinder(CurrencyList);
            double rate = RateFinder.FindRate(Name);
            return eur * rate;
        }
    }
}
