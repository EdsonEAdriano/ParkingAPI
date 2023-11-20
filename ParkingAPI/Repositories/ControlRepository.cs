using Microsoft.EntityFrameworkCore;
using ParkingAPI.Data;
using ParkingAPI.DTOs;
using ParkingAPI.Models;

namespace ParkingAPI.Repositories
{
    public class ControlRepository : IControlRepository
    {
        private readonly DatabaseContext _context;

        public ControlRepository(DatabaseContext context) 
        {
            _context = context;
        }

        public async Task<Control> add(ControlDTO controlDTO)
        {
            Control control = new Control();
            control.company = await _context.Companies.FirstOrDefaultAsync(c => c.id == controlDTO.companyID);
            control.vehicle = await _context.Vehicles.FirstOrDefaultAsync(c => c.id == controlDTO.vehicleID);

            await _context.Controls.AddAsync(control);
            await _context.SaveChangesAsync();

            return control;
        }

        public async Task<Control> exit(int id)
        {
            Control control = await get(id);
            control.status = Enums.ControlStatus.Exit;
            control.exitDate = DateTime.Now;

            TimeSpan diferenceDates = control.exitDate - control.createDate;

            Prices price = await _context.Prices
                .OrderBy(c => c.hours)
                .FirstAsync(p => p.hours >= (short)diferenceDates.Hours);

            control.price = price;

            _context.Controls.Update(control);
            await _context.SaveChangesAsync();

            return control;
        }

        public async Task<Control> get(int id)
        {
            Control control = await _context.Controls.FirstOrDefaultAsync(c => c.id == id);

            control.company = await _context.Companies.FirstOrDefaultAsync(c => c.id == control.companyID);
            control.vehicle = await _context.Vehicles.FirstOrDefaultAsync(c => c.id == control.vehicleID);
            return control;
        }

        public async Task<List<Control>> get()
        {
            return await _context.Controls.ToListAsync();
        }

        public async Task<Control> remove(int id)
        {
            Control control = await get(id);
            _context.Controls.Remove(control);
            await _context.SaveChangesAsync();

            return control;
        }

        public async Task<bool> exists(int id)
        {
            return await _context.Controls.AnyAsync(c => c.id == id); 
        }

        public async Task<bool> isParked(int id)
        {
            return await _context.Controls.AnyAsync(c => c.id == id && c.status == Enums.ControlStatus.Parked);
        }

        public async Task<bool> isParkedByDTO(ControlDTO controlDTO)
        {
            return await _context.Controls
                .AnyAsync(c => c.companyID == controlDTO.companyID 
                            && c.vehicleID == controlDTO.vehicleID
                            && c.status == Enums.ControlStatus.Parked
            );
        }
    }
}
