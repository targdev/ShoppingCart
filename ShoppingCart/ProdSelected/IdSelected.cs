using System;
using System.Collections.Generic;

namespace ShoppingCart.ProdSelected
{
    public class DelimitersToSplit
    {
        public List<int> Delimiter(string inputUser)
        {
            string[] delimiterChars = { " ", ",", ".", "...", ";", ":", "\\n", "[", "]", "//" };
            var userNumbers = inputUser.Split(delimiterChars, StringSplitOptions.None);
            List<int> listId = new List<int>();


            foreach (var num in userNumbers)
            {
                if (String.IsNullOrEmpty(num))
                {
                    continue;
                }

                listId.Add(Convert.ToInt32(num));
            }

            return listId;
        }
    }
}