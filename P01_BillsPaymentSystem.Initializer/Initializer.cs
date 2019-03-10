using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using P01_BillsPaymentSystem.Data;
using P01_BillsPaymentSystem.Data.Models;

namespace P01_BillsPaymentSystem.Initializer
{
    public class Initializer
    {
        
        public static void Seed(BillsPaymentSystemContext context)
        {
            InsertBankAccount(context);
            InsertCreditCard(context);
            InsertPaymentMethod(context);
            InsertUser(context);
        }

        private static void InsertUser(BillsPaymentSystemContext context)
        {
            var users = UserInitializer.GetUsers();

            for (int i = 0; i < users.Length; i++)
            {
                if (IsValid(users[i]))
                {
                    context.Users.Add(users[i]);
                }
            }
            context.SaveChanges();
        }

        private static void InsertPaymentMethod(BillsPaymentSystemContext context)
        {

            var paymentMethods = PaymentMethodInitializer.GetPaymentMethods();

            for (int i = 0; i < paymentMethods.Length; i++)
            {
                if (IsValid(paymentMethods[i]))
                {
                    context.PaymentMethods.Add(paymentMethods[i]);
                }
            }
            context.SaveChanges();
        }

        private static void InsertCreditCard(BillsPaymentSystemContext context)
        {
            var creditCards = CreditCardInitializer.GeCreditCards();

            for (int i = 0; i < creditCards.Length; i++)
            {
                if (IsValid(creditCards[i]))
                {
                    context.CreditCards.Add(creditCards[i]);
                }
            }
            context.SaveChanges();
        }

        private static void InsertBankAccount(BillsPaymentSystemContext context)
        {
            var bankAccounts = BankAccountInitializer.GetBankAccounts();

            for (int i = 0; i < bankAccounts.Length; i++)
            {
                if (IsValid(bankAccounts[i]))
                {
                    context.BankAccounts.Add(bankAccounts[i]);
                }
            }
            context.SaveChanges();

        }

        public static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var result = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext,result, true);
        }
        
    }
}
