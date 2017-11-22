using System;
using System.Collections.Generic;
namespace CurrencyConverter2
{
    public class FreeConverter
    {
        readonly List<Currency> CurrencyList;
        public FreeConverter(List<Currency> CurrencyList)
        {
            this.CurrencyList = CurrencyList;
        }
        public double Convert(string TargetCurrency, string OriginalCurrency, double OriginalValue)
        {
            RateFinder RateFinder = new RateFinder(CurrencyList);
            double OriginalRate = RateFinder.FindRate(OriginalCurrency);
            double TargetRate = RateFinder.FindRate(TargetCurrency);
            return OriginalValue * TargetRate / OriginalRate;
        }
    }
}
