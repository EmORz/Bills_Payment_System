using P01_BillsPaymentSystem.Data.Models;

namespace P01_BillsPaymentSystem.Initializer
{
    public class BankAccountInitializer
    {
        public static BankAccount[] GetBankAccounts()
        {
            BankAccount[] bankAccounts = new BankAccount[]
            {
                new BankAccount() {BankName= "Post bank", SwiftCode = "CRB", Balance = 2320.50m}, 
                //new BankAccount() {BankName= "Great bank", SwiftCode = "PRB", Balance = 2720.50m}, 
        
            };
            return bankAccounts;
        }
    }
}