﻿using Microsoft.EntityFrameworkCore;
using ParkingAPI.Data;
using ParkingAPI.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ParkingAPI.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly DatabaseContext _context;

        public VehicleRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Vehicle> add(Vehicle vehicle)
        {
            await _context.Vehicles.AddAsync(vehicle);
            await _context.SaveChangesAsync();
            return vehicle;
        }

        public async Task<Vehicle> edit(Vehicle vehicle)
        {
            _context.Vehicles.Update(vehicle);
            await _context.SaveChangesAsync();
            return vehicle;
        }


        public async Task<Vehicle> remove(long id)
        {
            var vehicle = await get(id);
            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();
            return vehicle; ;
        }

        public async Task<List<Vehicle>> get()
        {
            return await _context.Vehicles.ToListAsync();
        }

        public async Task<Vehicle> get(long id)
        {
            return await _context.Vehicles
                            .AsNoTracking()
                            .FirstOrDefaultAsync(vehicle => vehicle.id == id);
        }

        public async Task<bool> exists(long id)
        {
            return await _context.Vehicles.AnyAsync(c => c.id == id);
        }

        public async Task<bool> existsPlate(string plate)
        {
            return await _context.Vehicles.AnyAsync(c => c.plate.Trim() == plate);
        }
    }
}
