public class AppState
{
    public bool IsLoggedIn { get; set; }
    public string Username { get; set; }
    public decimal SaldoEuro { get; set; }
    public decimal SaldoUsd { get; set; }
    public decimal SaldoPen { get; set; }
    public List<Transaction> TransactionHistory { get; set; } = new List<Transaction>();


    public void Logout()
    {
        IsLoggedIn = false;
        Username = null;
        SaldoEuro = 0;
        SaldoUsd = 0;
        SaldoPen = 0;
    }
    public class Transaction
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }
}
