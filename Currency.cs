using System;
namespace CurrencyConverter2
{
    public class Currency
    {
        public string Name { get; set; }
        public double Rate { get; set; }

        public Currency(string Name, double Rate)
        {
            this.Name = Name;
            this.Rate = Rate;
        }
        public override string ToString()
        {
            return string.Format(Name + " " + Rate);
        }
    }
}
