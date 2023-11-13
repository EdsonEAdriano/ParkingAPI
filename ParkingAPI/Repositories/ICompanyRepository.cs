using ParkingAPI.Models;

namespace ParkingAPI.Repositories
{
    public interface ICompanyRepository
    {
        public Task<Company> add(Company company);
        public Task<Company> edit(Company company);
        public Task<Company> remove(long id);
        public Task<List<Company>> get();
        public Task<Company> get(long id);
    }
}
