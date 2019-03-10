using System;
using P01_BillsPaymentSystem.Data.Models;

namespace P01_BillsPaymentSystem.Initializer
{
    public class CreditCardInitializer
    {
        public static CreditCard[] GeCreditCards()
        {
            CreditCard[] creditCards = new CreditCard[]
            {
                new CreditCard() {Limit = 3000, MoneyOwed = 0, ExpirationDate = DateTime.Now.AddMonths(-12)},
                //new CreditCard() {Limit = 300, MoneyOwed = 0, ExpirationDate = DateTime.Now.AddMonths(-12)},

            };
            return creditCards;
        }
    }
}