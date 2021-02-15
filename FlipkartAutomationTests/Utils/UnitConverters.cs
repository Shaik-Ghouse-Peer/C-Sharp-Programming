using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace FlipkartAutomationTests.Utils
{
    [Binding]
    class UnitConverters
    {
        public static int ConvertPriceToInt32(string priceText)
        {
            int price;
            price = Convert.ToInt32(RemoveCommas(RemovePriceUnit(priceText)));

            return price;
        }
        private static string RemovePriceUnit(string priceText)
        {
            //Assuming PriceUnit is front of Price 
            return priceText.Remove(0, 1);
        }
        private static string RemoveCommas(string priceText)
        {
            return priceText.Replace(",", "");
        }
    }
}
