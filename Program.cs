using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TT
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static bool ScrollTo(Item item)
        {
            if (IsDisplayed(item))
            {
                return true;
            }
            else
            {
                int topIndex = 0;
                var previousTopItem = GetAllDisplayedItems()[0];
                while (true)
                {
                    Scroll();
                    if (IsDisplayed(item))
                    {
                        return true;
                    }
                    if (previousTopItem == GetAllDisplayedItems()[topIndex])
                    {
                        return false;
                    }
                    else
                    {
                        previousTopItem = GetAllDisplayedItems()[topIndex];
                    }

                }
            }
        }


        public static void ExtraEntryCount(int numOfProducts)
        {
            List<string> products = new List<string>();
            for(int i = 1; i <= numOfProducts; i++)
            {
                products.Add(GetProductsListById(i));
            }

            Dictionary<string, int> extrasDictionary = new Dictionary<string, int>();

            foreach (var product in products)
            {
                List<string> extraProducts = GetExtraProduct(product);
                foreach (var extraProduct in extraProducts)
                {
                    if (extrasDictionary.ContainsKey(extraProduct))
                    {
                        extrasDictionary[extraProduct] = extrasDictionary[extraProduct] + 1;
                    }
                    else
                    {
                        extrasDictionary.Add(extraProduct, 1);
                    }
                }

            }

            foreach (KeyValuePair<string, int> keyValue in extrasDictionary)
            {
                Console.WriteLine($"{keyValue.Key}, {keyValue.Value}");
            }

        }
       
    }
}
