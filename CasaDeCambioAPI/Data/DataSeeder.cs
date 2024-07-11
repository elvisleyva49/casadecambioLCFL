using CasaDeCambioAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CasaDeCambioAPI.Data
{
    public class DataSeeder
    {
        private readonly CasaDeCambioContext _context;

        public DataSeeder(CasaDeCambioContext context)
        {
            _context = context;
        }

        public void SeedData()
        {

            _context.Database.EnsureCreated();

            if (!_context.Users.Any())
            {
                var defaultUser = new User
                {
                    Username = "admin",
                    Password = "admin",
                    Balance = 1000m
                };

                _context.Users.Add(defaultUser);
                _context.SaveChanges();
            }
        }
    }
}
