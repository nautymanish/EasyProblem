using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcualteTax
{
    public interface IRateCalculator
    {
        double CalculateBill(Basket basket, User user);
        DiscountType GetPercentDiscount { get; }
        decimal FixedDiscount { get; }
    }
}
