using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_BillsPaymentSystem.Data.Models
{
    public class CreditCard
    {
        //o CreditCardId
        //o Limit
        //o MoneyOwed
        //o LimitLeft(calculated property, not included in the database)
        //o ExpirationDate
        [Key]
        public int CreditCardId { get; set; }

        public decimal Limit { get; set; }

        public decimal MoneyOwed { get; set; }

        [NotMapped]
        public decimal LimitLeft => Limit - MoneyOwed;

        public DateTime ExpirationDate { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        //Method =>
        //Add Withdraw() and Deposit() methods to the BankAccount and CreditCard classes

        public void Deposit(decimal amount)
        {
            if (amount >= 0)
            {
                this.MoneyOwed -= amount;
            }

        }

        public void Withdraw(decimal amount)
        {
            if (this.LimitLeft - amount >= 0)
            {
                this.MoneyOwed += amount;
            }
        }



    }
}