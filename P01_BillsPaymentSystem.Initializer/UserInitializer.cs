using P01_BillsPaymentSystem.Data.Models;

namespace P01_BillsPaymentSystem.Initializer
{
    public class UserInitializer
    {
        public static User[] GetUsers()
        {
            User[] users = new User[]
            {
                new User() {FirstName = "Gosho0", LastName = "Peshev0", Email = "g.peshev0@cia.gov", Password = "GTk#JD"},
                new User() {FirstName = "Gosho1", LastName = "Peshev1", Email = "g.pesh12ev0@cia.gov", Password = "GTk#JD"}
            };
            return users;
        }
    }
}