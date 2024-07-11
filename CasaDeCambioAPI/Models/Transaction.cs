namespace CasaDeCambioAPI.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Type { get; set; }  // Deposit, Withdraw, Convert
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
