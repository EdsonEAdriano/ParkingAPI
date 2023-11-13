using Microsoft.EntityFrameworkCore;
using ParkingAPI.Data;
using ParkingAPI.Models;

namespace ParkingAPI.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DatabaseContext _context;

        public CompanyRepository(DatabaseContext context) 
        {
            _context = context;
        }

        public async Task<Company> add(Company company)
        {
            await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync();
            return company;
        }

        public async Task<Company> edit(Company company)
        {
            _context.Companies.Update(company);
            await _context.SaveChangesAsync();
            return company;
        }

        public async Task<Company> remove(long id)
        {
            var company = await get(id);
            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
            return company;
        }

        public async Task<List<Company>> get()
        {
            return await _context.Companies.ToListAsync();
        }

        public async Task<Company> get(long id)
        {
            return await _context.Companies.FirstOrDefaultAsync(company => company.id == id);
        }
    }
}
