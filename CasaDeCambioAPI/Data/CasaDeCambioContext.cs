using Microsoft.EntityFrameworkCore;
using CasaDeCambioAPI.Models;

namespace CasaDeCambioAPI.Data
{
    public class CasaDeCambioContext : DbContext
    {
        public CasaDeCambioContext(DbContextOptions<CasaDeCambioContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}
