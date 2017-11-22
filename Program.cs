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
            FromEURConverter FromEURConverter = new FromEURConverter(CurrencyList);
            int ChoiceInput = 0;
            double ValueInput;
            string NameInput;
            double ValueResult;

            //MENU
            Console.WriteLine("*****MENU*****");
            Console.WriteLine("1. View available currencies");
            Console.WriteLine("2. Find exchange rate");
            Console.WriteLine("3. Convert from Euro");
            try
            {
				ChoiceInput = Int32.Parse(Console.ReadLine());
            } catch (FormatException e)
            {
                Main(args);
            }

            if (ChoiceInput == 1)
            {
				foreach (var Currency in CurrencyList)
				{
					Console.WriteLine(Currency);
				}
            }

            else if (ChoiceInput == 2)
            {
				Console.WriteLine("Enter currency: ");
				NameInput = Console.ReadLine();
				Console.WriteLine(RateFinder.FindRate(NameInput.ToUpper()));            
            }

            else if (ChoiceInput == 3)
            {
                Console.WriteLine("Enter currency: ");
                NameInput = Console.ReadLine();
                Console.WriteLine("Enter amount in Euro: ");
                ValueInput = Double.Parse(Console.ReadLine());
                ValueResult = FromEURConverter.ConvertFromEUR(NameInput.ToUpper(), ValueInput);
                Console.WriteLine("You can get {0} {1} from {2} EUR.", Math.Round(ValueResult, 2), NameInput.ToUpper(), Math.Round(ValueInput, 2));
            }
            else
            {
                Console.WriteLine("Your input was invalid.");
            }
        }
    }
}
