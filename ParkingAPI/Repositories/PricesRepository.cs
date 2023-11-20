using Microsoft.EntityFrameworkCore;
using ParkingAPI.Data;
using ParkingAPI.Models;

namespace ParkingAPI.Repositories
{
    public class PricesRepository : IPricesRepository
    {
        private readonly DatabaseContext _context;

        public PricesRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Prices> add(Prices price)
        {
            await _context.Prices.AddAsync(price);
            await _context.SaveChangesAsync();
            return price;
        }

        public async Task<Prices> delete(Prices price)
        {
            _context.Prices.Remove(price);
            await _context.SaveChangesAsync();
            return price;
        }

        public async Task<List<Prices>> get()
        {
            return await _context.Prices.ToListAsync();
        }

        public async Task<Prices> get(short id)
        {
            return await _context.Prices.FirstOrDefaultAsync(p => p.id == id);
        }

        public async Task<Prices> update(Prices price)
        {
            _context.Prices.Update(price);
            await _context.SaveChangesAsync();
            return price;
        }
    }
}
