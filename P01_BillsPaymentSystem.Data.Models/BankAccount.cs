using System.ComponentModel.DataAnnotations;
using P01_BillsPaymentSystem.Data.Models.Attributes;

namespace P01_BillsPaymentSystem.Data.Models
{
    public class BankAccount
    {
        //o BankAccountId
        //o Balance
        //o BankName(up to 50 characters, unicode)
        //o SWIFT Code(up to 20 characters, non-unicode)

        [Key]
        public int BankAccountId { get; set; }

        [Required]
        public decimal Balance { get; set; }

        [Required]
        [MaxLength(50)]
        public string BankName { get; set; }

        [Required]
        [MaxLength(20)]
        [NonUnicodeAttributes]
        public string SwiftCode { get; set; }


        public PaymentMethod PaymentMethod { get; set; }

        //Method => 
        //Add Withdraw() and Deposit() methods to the BankAccount and CreditCard classes

        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                this.Balance += amount;
            }

        }

        public void Withdraw(decimal amount)
        {
            if ( this.Balance - amount > 0)
            {
                this.Balance -= amount;

            }
        }

    


    }
}