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
            ToEURConverter ToEURConverter = new ToEURConverter(CurrencyList);
            int ChoiceInput = 0;
            double ValueInput = 0.0;
            string NameInput = null;
            double ValueResult = 0.0;

            //MENU
            Console.WriteLine("*****MENU*****");
            Console.WriteLine("1. View available currencies");
            Console.WriteLine("2. Find exchange rate");
            Console.WriteLine("3. Convert from Euro");
            Console.WriteLine("4. Convert to Euro");
            Console.WriteLine("5. Log out");
            try
            {
				ChoiceInput = Int32.Parse(Console.ReadLine());
            } catch (FormatException e)
            {
                Console.WriteLine("Your input was invalid.");
                Main(args);
            }

            switch (ChoiceInput)
            {
                //1. View available currencies
                case 1:
                    foreach (var Currency in CurrencyList)
                    {
                        Console.WriteLine(Currency);
                    }
                    Main(args);
                    break;
                //2. Find exchange rate
                case 2:
                    Console.WriteLine("Enter currency: ");
                    NameInput = Console.ReadLine();
                    if(NameInput.ToUpper().Equals("EUR"))
                    {
                        Console.WriteLine("1 EUR = 1 EUR");
                    }
                    else if(!RateFinder.CurrencyExists(NameInput.ToUpper()))
                    {
                        Console.WriteLine("Your input was invalid");
                    } else
                    {
						Console.WriteLine("1 EUR = {0} {1}", RateFinder.FindRate(NameInput.ToUpper()), NameInput.ToUpper());
                    }
					Main(args);   
                    break;
                //3. Convert from Euro
                case 3:
                    Console.WriteLine("Enter currency: ");
                    NameInput = Console.ReadLine();
                    if (!RateFinder.CurrencyExists(NameInput.ToUpper()))
                    {
                        Console.WriteLine("Your input was invalid");
                        Main(args);
                    }
                    else
                    {
						Console.WriteLine("Enter amount in Euro: ");
						try
						{
							ValueInput = Double.Parse(Console.ReadLine());
						}
						catch (FormatException e)
						{
							Console.WriteLine("Your input was invalid.");
							Main(args);
						}
						ValueResult = FromEURConverter.ConvertFromEUR(NameInput.ToUpper(), ValueInput);
						Console.WriteLine("You can get {0} {1} from {2} EUR.", Math.Round(ValueResult, 2), NameInput.ToUpper(), Math.Round(ValueInput, 2));
						Main(args);
                        
                    }
                    break;
                //4. Convert to Euro
                case 4:
                    Console.WriteLine("Enter currency: ");
                    NameInput = Console.ReadLine();
                    if(!RateFinder.CurrencyExists(NameInput.ToUpper()))
                    {
                        Console.WriteLine("Your input was invalid");
                        Main(args);
                    }
                    else
                    {
                        Console.WriteLine("Enter amount in your currency: ");
                        try
                        {
                            ValueInput = Double.Parse(Console.ReadLine());
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("Your input was invalid");
                            Main(args);
                        }
                        ValueResult = ToEURConverter.ConvertToEUR(NameInput.ToUpper(), ValueInput);
                        Console.WriteLine("You can get {0} EUR from {1} {2}.", Math.Round(ValueResult, 2), Math.Round(ValueInput, 2), NameInput);
                        Main(args);
                    }
                    break;
                //5. Log out
                case 5:
                    Environment.Exit(1);
                    break;
                default:
                    Console.WriteLine("Your input was invalid.");
                    Main(args);
                    break;
            }
        }
    }
}
