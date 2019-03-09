using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using P01_BillsPaymentSystem.Data.Models.Attributes;

namespace P01_BillsPaymentSystem.Data.Models
{
    public class User
    {
        //o UserId
        //o FirstName(up to 50 characters, unicode)
        //o LastName(up to 50 characters, unicode)
        //o Email(up to 80 characters, non-unicode)
        //o Password(up to 25 characters, non-unicode)

        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(80)]
        [NonUnicodeAttributes]
        public string Email { get; set; }

        [Required]
        [MaxLength(25)]
        [NonUnicodeAttributes]
        public string Password { get; set; }

        public ICollection<PaymentMethod> PaymentMethods { get; set; }
    }
}
