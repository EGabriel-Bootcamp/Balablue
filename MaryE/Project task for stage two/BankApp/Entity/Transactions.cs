namespace BankApp.Entity
{
    public class Transactions
    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string UserName { get; set; }

        public Transactions(string username, decimal amount, DateTime date)
        {
            UserName= username;
            Amount = amount;
            Date = date;
        }
    }

}
