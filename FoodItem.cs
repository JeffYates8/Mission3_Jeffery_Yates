using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodBankInventorySystem
{
    class FoodItem
    {
        public string FoodName { get; private set; }
        public string FoodCategory { get; private set; }
        public int FoodQuantity { get; private set; }
        public DateTime ExpirationDate { get; private set; }

        public FoodItem(string foodName, string foodCategory, int foodQuantity, DateTime expirationDate)
        {
            FoodName = foodName;
            FoodCategory = foodCategory;
            FoodQuantity = foodQuantity;
            ExpirationDate = expirationDate;
        }
    }
}
