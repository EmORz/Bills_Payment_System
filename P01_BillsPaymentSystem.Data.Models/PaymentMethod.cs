using System.ComponentModel.DataAnnotations;
using P01_BillsPaymentSystem.Data.Models.Attributes;

namespace P01_BillsPaymentSystem.Data.Models
{
    public class PaymentMethod
    {
        //o Id - PK
        //    o   Type – enum (BankAccount, CreditCard)
        //    o   UserId
        //    o   BankAccountId
        //    o   CreditCardId
        [Key]
        public int Id { get; set; }

        [Required]
        public PaymentType Type { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        [Xor(nameof(BankAccount))]
        public int? CreditCardId { get; set; }
        public CreditCard CreditCard { get; set; }

        public int? BankAccountId { get; set; }
        public BankAccount BankAccount { get; set; }

    }
}