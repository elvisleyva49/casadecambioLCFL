using Microsoft.AspNetCore.Mvc;
using CasaDeCambioAPI.Models;
using CasaDeCambioAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace CasaDeCambioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly CasaDeCambioContext _context;

        public TransactionsController(CasaDeCambioContext context)
        {
            _context = context;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetTransactions(int userId)
        {
            var transactions = await _context.Transactions
                .Where(t => t.UserId == userId)
                .ToListAsync();
            return Ok(transactions);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            return Ok(transaction);
        }
    }
}
