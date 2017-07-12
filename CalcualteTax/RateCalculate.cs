using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcualteTax
{
    public class RateCalculate : IRateCalculator
    {
        public decimal FixedDiscount
        {
            get
            {
                return 5;
            }
        }

        public DiscountType GetPercentDiscount
        {
            get; set;
           
        }

        public double CalculateBill(Basket basket, User user)
        {
            try
            {
                var costForDiscount = basket.Items.Where(item => item.Type != "Grocery").Select(item => item.Cost).Sum();
                switch (GetPercentDiscount)
                {
                    case DiscountType.FivePercent: costForDiscount -= costForDiscount - (costForDiscount * 0.05); break;
                    case DiscountType.TenPercent: costForDiscount -= costForDiscount - (costForDiscount * 0.1); break;
                    case DiscountType.ThirtyPercent: costForDiscount -= costForDiscount - (costForDiscount * 0.3); break;
                }
                var totalCost = basket.Items.Select(item => item.Cost).Sum() - costForDiscount;
                totalCost = totalCost - (Math.Truncate(totalCost / 100) * 5);
                return totalCost;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

       
    }
}
