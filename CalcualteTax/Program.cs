using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcualteTax
{
    class Program
    {
        static void Main(string[] args)
        {
            Basket basket = new Basket();
            basket.Items = new List<Items>();
            basket.Items.Add(new CalcualteTax.Items(5.5, "Grocery"));
            basket.Items.Add(new CalcualteTax.Items(100, "Perfume"));
            basket.Items.Add(new CalcualteTax.Items(100, "Electrical"));
            var user= new User() { UserType = EmployeeType.CompanyEmployee, UserWithUsInyears = 2 };
            RateCalculate rateCalc = new RateCalculate();
            rateCalc.GetPercentDiscount = DiscountType.ThirtyPercent;
            rateCalc.CalculateBill(basket, user);
        }
    }
}
