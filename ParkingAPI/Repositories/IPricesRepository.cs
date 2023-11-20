using ParkingAPI.Models;

namespace ParkingAPI.Repositories
{
    public interface IPricesRepository
    {
        public Task<Prices> add(Prices price);
        public Task<List<Prices>> get();
        public Task<Prices> get(short id);
        public Task<Prices> update(Prices price);
        public Task<Prices> delete(Prices price);
    }
}
