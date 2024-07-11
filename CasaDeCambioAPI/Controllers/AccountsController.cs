using Microsoft.AspNetCore.Mvc;
using CasaDeCambioAPI.Models;
using CasaDeCambioAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace CasaDeCambioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly CasaDeCambioContext _context;

        public AccountsController(CasaDeCambioContext context)
        {
            _context = context;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAccounts(int userId)
        {
            var accounts = await _context.Accounts
                .Where(a => a.UserId == userId)
                .ToListAsync();
            return Ok(accounts);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount(Account account)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
            return Ok(account);
        }

        [HttpPut("{accountId}")]
        public async Task<IActionResult> UpdateAccount(int accountId, Account account)
        {
            if (accountId != account.Id)
                return BadRequest();

            _context.Entry(account).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
