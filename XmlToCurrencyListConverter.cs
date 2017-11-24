using System;
using System.Collections.Generic;
using System.Xml;

namespace CurrencyConverter2
{
    public class XmlToCurrencyListConverter
    {
        public List<Currency> GetCurrencyList()
        {
            XmlReader XmlReader = XmlReader.Create("https://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml");
            List<Currency> CurrencyList = new List<Currency>();
            try
            {
                while (XmlReader.Read())
                {
                    if ((XmlReader.NodeType == XmlNodeType.Element) && (XmlReader.Name == "Cube") && XmlReader.GetAttribute("currency") != null)
                    {
                        string Name = XmlReader.GetAttribute("currency");
                        double Rate = Double.Parse(XmlReader.GetAttribute("rate"));
                        CurrencyList.Add(new Currency(Name, Rate));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error reading file: {0}", e);
            }
            finally
            {
                XmlReader.Close();
            }
            return CurrencyList;
        }
    }
}
