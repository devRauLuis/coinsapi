using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using coinsapi.Data;
using coinsapi.Models;

namespace coinapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoinsController : ControllerBase
    {
        private readonly CoinsDbContext _context;

        public CoinsController(CoinsDbContext context)
        {
            _context = context;
        }

        // GET: api/Coins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coin>>> GetCoins()
        {
            if (_context.Coins == null)
            {
                return NotFound();
            }
            return await _context.Coins.ToListAsync();
        }

        // GET: api/Coins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Coin>> GetCoin(string id)
        {
            if (_context.Coins == null)
            {
                return NotFound();
            }
            var coin = await _context.Coins.FindAsync(id);

            if (coin == null)
            {
                return NotFound();
            }

            return coin;
        }

        // PUT: api/Coins/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoin(string id, Coin coin)
        {
            if (id != coin.Id)
            {
                return BadRequest();
            }

            _context.Entry(coin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoinExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Coins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Coin>> PostCoin(Coin coin)
        {
            if (_context.Coins == null)
            {
                return Problem("Entity set 'CoinsDbContext.Coins'  is null.");
            }
            _context.Coins.Add(coin);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CoinExists(coin.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCoin", new { id = coin.Id }, coin);
        }

        [HttpPost]
        [Route("ReceiveAll")]
        public async Task<ActionResult<CoinsArr>> ReceiveAll(CoinsArr coins)
        {
            if (_context.Coins == null)
            {
                {
                    return Problem("Entity set 'CoinsDbContext.Coins'  is null.");
                }
            }

            foreach (var coin in coins.Coins)
            {
                _context.Coins.Add(coin);
            }

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ReceiveAll), new { }, coins);
        }

        // DELETE: api/Coins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoin(string id)
        {
            if (_context.Coins == null)
            {
                return NotFound();
            }
            var coin = await _context.Coins.FindAsync(id);
            if (coin == null)
            {
                return NotFound();
            }

            _context.Coins.Remove(coin);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CoinExists(string id)
        {
            return (_context.Coins?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
