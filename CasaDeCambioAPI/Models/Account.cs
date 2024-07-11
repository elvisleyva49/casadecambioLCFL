namespace CasaDeCambioAPI.Models
{
    public class Account
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Currency { get; set; }  // USD, EUR, etc.
        public decimal Balance { get; set; }
    }
}
