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
                new BankAccount() {BankName= "Deusche bank", SwiftCode = "pRB", Balance = 2420.50m}, 
                new BankAccount() {BankName= "Turkish bank", SwiftCode = "kmn", Balance = 2300.50m}, 
                new BankAccount() {BankName= "BNB bank", SwiftCode = "hhh", Balance = 2328.50m}, 
                new BankAccount() {BankName= "Japan bank", SwiftCode = "jjj", Balance = 23240.50m}, 
                new BankAccount() {BankName= "Macedonian bank", SwiftCode = "CRB", Balance = 23520.50m}, 
                new BankAccount() {BankName= "Rubur bank", SwiftCode = "xcx", Balance = 23200.50m}, 
                new BankAccount() {BankName= "WoW bank", SwiftCode = "szx", Balance = 234720.50m}, 
                new BankAccount() {BankName= "bug bank", SwiftCode = "sda", Balance = 232120.50m}, 
                new BankAccount() {BankName= "Birnik bank", SwiftCode = "CRB", Balance = 212320.50m}, 
                new BankAccount() {BankName= "Kodja bank", SwiftCode = "sap", Balance = 239520.50m}, 
                new BankAccount() {BankName= "BB bank", SwiftCode = "kol", Balance = 235520.50m}, 
                new BankAccount() {BankName= "RR bank", SwiftCode = "lop", Balance = 2345620.50m}, 
            };


            return bankAccounts;
        }
    }
}