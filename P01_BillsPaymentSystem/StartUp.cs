using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using P01_BillsPaymentSystem.Data;
using P01_BillsPaymentSystem.Data.Models;

namespace P01_BillsPaymentSystem
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (BillsPaymentSystemContext context = new BillsPaymentSystemContext())
            {
               //context.Database.EnsureDeleted();
               //context.Database.EnsureCreated();
               // Initializer.Initializer.Seed(context);
                User user = GetUsers(context);
                GetInfo(user);
                PayBills(user, 3000);
            }
            //Console.WriteLine("Hello World!");


        }

        public static void PayBills(User user, decimal amount)
        {
            var bankAccountsTotal =
                user.PaymentMethods.Where(x => x.BankAccount != null).Sum(x => x.BankAccount.Balance);
            var creditCardTotal =
                user.PaymentMethods.Where(x => x.CreditCard != null).Sum(x => x.CreditCard.LimitLeft);

            var totalAmount = bankAccountsTotal + creditCardTotal;

            if (totalAmount >= amount)
            {
                var bankAccounts =
                    user.PaymentMethods.Where(x => x.BankAccount != null).Select(x => x.BankAccount).OrderBy(x => x.BankAccountId);
                foreach (var bankAccount in bankAccounts)
                {
                    if (bankAccount.Balance >= amount)
                    {
                        bankAccount.Withdraw(amount);
                        amount = 0;
                    }
                    else
                    {
                        amount -= bankAccount.Balance;
                        bankAccount.Withdraw(bankAccount.Balance);
                    }

                    if (amount==0)
                    {
                        return;
                        
                    }
                }
                var creditCards =
                    user.PaymentMethods.Where(x => x.CreditCard != null).Select(x => x.CreditCard).OrderBy(x => x.CreditCardId);

                foreach (var creditCard in creditCards)
                {
                    if (creditCard.LimitLeft>=amount)
                    {
                        creditCard.Withdraw(amount);
                        amount = 0;

                    }
                    else
                    {
                        amount -= creditCard.LimitLeft;
                        creditCard.Withdraw(creditCard.LimitLeft);
                    }

                    if (amount == 0)
                    {
                        return;

                    }
                }

            }
        }

        private static void GetInfo(User user)
        {
            Console.WriteLine($"User: {user.FirstName} {user.LastName}");
            Console.WriteLine("Bank Accounts:");
            var bankAccounts = user.PaymentMethods.Where(x => x.BankAccount != null).Select(x => x.BankAccount).ToArray();
            foreach (var bankAccount in bankAccounts)
            {
                Console.WriteLine($"-- Id: {bankAccount.BankAccountId}");
                Console.WriteLine($"-- - Balance: {bankAccount.Balance:f2}");
                Console.WriteLine($"-- - Bank: {bankAccount.BankName}");
                Console.WriteLine($"-- - SWIFT: {bankAccount.SwiftCode}");

            }

            Console.WriteLine("Credit Cards:");
            var creditCards = user.PaymentMethods.Where(x => x.CreditCard != null).Select(x => x.CreditCard).ToArray();
            foreach (var creditCard in creditCards)
            {
                Console.WriteLine($"-- Id: {creditCard.CreditCardId}");
                Console.WriteLine($"-- - Limit: {creditCard.Limit:f2}");
                Console.WriteLine($"-- - Money Owed: {creditCard.MoneyOwed}");
                Console.WriteLine($"-- - Limit Left: {creditCard.LimitLeft:f2}");
                Console.WriteLine($"-- - Expriration Date: {creditCard.ExpirationDate.ToString("yyyy/MM")}");
            }
        }


        private static User GetUsers(BillsPaymentSystemContext context)
        {
            var userId = int.Parse(Console.ReadLine());

            User user = null;

            while (true)
            {
                user = context.Users.Where(x => x.UserId == userId)
                    .Include(x => x.PaymentMethods)
                    .ThenInclude(x => x.CreditCard)
                    .Include(x => x.PaymentMethods)
                    .ThenInclude(x => x.BankAccount)
                    .FirstOrDefault();

                if (user == null)
                {
                    userId = int.Parse(Console.ReadLine());
                    continue;
                }

                break;
            }
            

            return user;

        }
    }
}
