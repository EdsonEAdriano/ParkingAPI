using ParkingAPI.Models;

namespace ParkingAPI.Repositories
{
    public interface IVehicleRepository
    {
        public Task<Vehicle> add(Vehicle vehicle);
        public Task<Vehicle> edit(Vehicle vehicle);
        public Task<Vehicle> remove(long id);
        public Task<List<Vehicle>> get();
        public Task<Vehicle> get(long id);
        public Task<bool> exists(long id);
    }
}
