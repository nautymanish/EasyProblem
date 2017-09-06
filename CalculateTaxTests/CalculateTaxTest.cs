using CalcualteTax;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CalculateTaxTests
{
    [TestClass]
    public class CalculateTaxTest
    {
        [TestMethod]
        public void TestThirtyPercent()
        {
            Basket basket = new Basket();
            basket.Items = new List<Items>();
            basket.Items.Add(new CalcualteTax.Items(5.5, "Grocery"));
            basket.Items.Add(new CalcualteTax.Items(100, "Perfume"));
            basket.Items.Add(new CalcualteTax.Items(100, "Electrical"));
            var user = new User() { UserType = EmployeeType.CompanyEmployee, UserWithUsInyears = 2 };
            RateCalculate rateCalc = new CalcualteTax.RateCalculate();
            rateCalc.GetPercentDiscount = DiscountType.ThirtyPercent;
            Assert.AreEqual(140.5,rateCalc.CalculateBill(basket, user));
        }

        [TestMethod]
        public void TestTenPercent()
        {
            Basket basket = new Basket();
            basket.Items = new List<Items>();
            basket.Items.Add(new CalcualteTax.Items(5.5, "Grocery"));
            basket.Items.Add(new CalcualteTax.Items(600, "Perfume"));
            basket.Items.Add(new CalcualteTax.Items(300, "Electrical"));
            var user = new User() { UserType = EmployeeType.CompanyEmployee, UserWithUsInyears = 2 };
            RateCalculate rateCalc = new CalcualteTax.RateCalculate();
            rateCalc.GetPercentDiscount = DiscountType.TenPercent;
            Assert.AreEqual(775.5, rateCalc.CalculateBill(basket, user));
        }
        [TestMethod]
        public void TestFivePercent()
        {
            Basket basket = new Basket();
            basket.Items = new List<Items>();
            basket.Items.Add(new CalcualteTax.Items(5.5, "Grocery"));
            basket.Items.Add(new CalcualteTax.Items(60, "Perfume"));
            basket.Items.Add(new CalcualteTax.Items(30, "Electrical"));
            var user = new User() { UserType = EmployeeType.CompanyEmployee, UserWithUsInyears = 2 };
            RateCalculate rateCalc = new CalcualteTax.RateCalculate();
            rateCalc.GetPercentDiscount = DiscountType.FivePercent;
            Assert.AreEqual(91, rateCalc.CalculateBill(basket, user));
        }

        [TestMethod]
        public void TestPercentDoesnotApplyOnGrocery()
        {
            Basket basket = new Basket();
            basket.Items = new List<Items>();
            basket.Items.Add(new CalcualteTax.Items(20, "Grocery"));
            basket.Items.Add(new CalcualteTax.Items(100, "Grocery"));
            basket.Items.Add(new CalcualteTax.Items(30, "Grocery"));
            var user = new User() { UserType = EmployeeType.CompanyEmployee, UserWithUsInyears = 2 };
            RateCalculate rateCalc = new CalcualteTax.RateCalculate();
            Assert.AreEqual(145, rateCalc.CalculateBill(basket, user));
            basket.Items.Clear();
            basket.Items.Add(new CalcualteTax.Items(20.5, "TestCategory"));
            basket.Items.Add(new CalcualteTax.Items(100, "TestCategory"));
            basket.Items.Add(new CalcualteTax.Items(30, "TestCategory"));
            rateCalc.GetPercentDiscount = DiscountType.ThirtyPercent;
            Assert.AreEqual(100.35, rateCalc.CalculateBill(basket, user));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestExceptions()
        {
            Basket basket = new Basket();
            var user = new User();
            RateCalculate rateCalc = new CalcualteTax.RateCalculate();
            rateCalc.CalculateBill(basket, user);
        }

    }
}
