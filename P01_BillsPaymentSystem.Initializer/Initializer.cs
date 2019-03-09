using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using P01_BillsPaymentSystem.Data;

namespace P01_BillsPaymentSystem.Initializer
{
    public class Initializer
    {
        //pokop
        public static void Seed(BillsPaymentSystemContext context)
        {
            InsertBankAccount(context);
            InsertCreditCard(context);
            InsertPaymentMethod(context);
            InsertUser(context);
        }

        private static void InsertUser(BillsPaymentSystemContext context)
        {
            throw new NotImplementedException();
        }

        private static void InsertPaymentMethod(BillsPaymentSystemContext context)
        {
            throw new NotImplementedException();
        }

        private static void InsertCreditCard(BillsPaymentSystemContext context)
        {
            throw new NotImplementedException();
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
