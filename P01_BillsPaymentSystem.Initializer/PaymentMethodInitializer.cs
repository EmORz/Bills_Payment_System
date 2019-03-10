using P01_BillsPaymentSystem.Data.Models;

namespace P01_BillsPaymentSystem.Initializer
{
    public class PaymentMethodInitializer
    {
        public static PaymentMethod[] GetPaymentMethods()
        {
            PaymentMethod[] paymentMethods = new PaymentMethod[]
            {
                new PaymentMethod() {UserId = 1, BankAccountId = 1, Type = PaymentType.BankAccount},
               // new PaymentMethod() {UserId = 1, CreditCardId = 1, Type = PaymentType.CreditCard},

            };
            return paymentMethods;
        }
    }
}