using System;
using System.Xml;
using System.Collections.Generic;

namespace CurrencyConverter2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            XmlToCurrencyListConverter XmlConverter = new XmlToCurrencyListConverter();
			var CurrencyList = new List<Currency>();
			CurrencyList = XmlConverter.GetCurrencyList();
            RateFinder RateFinder = new RateFinder(CurrencyList);
            String NameInput;

            Console.WriteLine("Enter currency: ");
            NameInput = Console.ReadLine();
            Console.WriteLine(RateFinder.FindRate(NameInput));

            foreach (var Currency in CurrencyList)
            {
                Console.WriteLine(Currency);
            }
        }
    }
}
