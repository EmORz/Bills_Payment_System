using System.ComponentModel.DataAnnotations;

namespace P01_BillsPaymentSystem.Data.Models.Attributes
{
    public class NonUnicodeAttributes : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var nullErrorMesage = "Value can not be null";
            var unicodeErrorMesage = "Value can not be null";

            if (value == null)
            {
                return  new ValidationResult(nullErrorMesage);
            }

            var text = (string)value;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i]> 255)
                {
                    return  new ValidationResult(unicodeErrorMesage);
                }
            }
            return ValidationResult.Success;
        }
    }
}