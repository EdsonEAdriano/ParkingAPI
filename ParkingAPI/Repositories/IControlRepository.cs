﻿using ParkingAPI.DTOs;
using ParkingAPI.Models;

namespace ParkingAPI.Repositories
{
    public interface IControlRepository
    {
        Task<Control> get(int id);
        Task<List<Control>> get();
        Task<Control> add(ControlDTO controlDTO);
        Task<Control> exit(int id);
        Task<Control> remove(int id);
    }
}
