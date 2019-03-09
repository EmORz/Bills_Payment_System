using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_BillsPaymentSystem.Data.Models;

namespace P01_BillsPaymentSystem.Data.EntityConfiguration
{
    public class PaymentMethodConfig : IEntityTypeConfiguration<PaymentMethod>

    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            throw new System.NotImplementedException();
        }
    }
}