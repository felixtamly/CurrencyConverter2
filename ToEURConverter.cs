using System;
using System.Collections.Generic;

namespace CurrencyConverter2
{
    public class ToEURConverter
    {
        readonly List<Currency> CurrencyList;
        public ToEURConverter(List<Currency> CurrencyList)
        {
            this.CurrencyList = CurrencyList;
        }
        public double ConvertToEUR(string Name, double Amount)
        {
            RateFinder RateFinder = new RateFinder(CurrencyList);
            double Rate = RateFinder.FindRate(Name);
            return Amount / Rate;
        }
    }
}
