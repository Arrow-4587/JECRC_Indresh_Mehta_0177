using Microsoft.AspNetCore.Mvc;
using BankingApi.Data;
using BankingApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BankingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TransactionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET ALL
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Transactions.ToListAsync());
        }

        // GET BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var txn = await _context.Transactions.FindAsync(id);
            if (txn == null) return NotFound();
            return Ok(txn);
        }

        // CREATE
        [HttpPost]
        public async Task<IActionResult> Create(Transaction txn)
        {
            _context.Transactions.Add(txn);
            await _context.SaveChangesAsync();
            return Ok(txn);
        }

        // UPDATE
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Transaction txn)
        {
            if (id != txn.Id) return BadRequest();

            _context.Entry(txn).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(txn);
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var txn = await _context.Transactions.FindAsync(id);
            if (txn == null) return NotFound();

            _context.Transactions.Remove(txn);
            await _context.SaveChangesAsync();

            return Ok("Deleted");
        }

        // FILTER BY DATE
        [HttpGet("filter")]
        public async Task<IActionResult> Filter(string date)
        {
            var result = await _context.Transactions
                .Where(t => t.Date == date)
                .ToListAsync();

            return Ok(result);
        }

        // SORT BY AMOUNT
        [HttpGet("sort")]
        public async Task<IActionResult> Sort()
        {
            var result = await _context.Transactions
                .OrderBy(t => t.Amount)
                .ToListAsync();

            return Ok(result);
        }
    }
}
