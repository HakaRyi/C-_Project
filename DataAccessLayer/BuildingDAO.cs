using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class BuildingDAO
    {
        private readonly PodBookingSystemContext _context;

        public BuildingDAO(PodBookingSystemContext context)
        {
            _context = context;
        }

        // Get all buildings with associated rooms
        public List<Building> GetAllBuildings()
        {
            return _context.Buildings.Include(b => b.Rooms).ToList();
        }

        public Building GetBuildingById(string buildingId)
        {
            return _context.Buildings.Include(b => b.Rooms)
                .FirstOrDefault(b => b.BuildingId == buildingId);
        }

        public void AddBuilding(Building building)
        {
            _context.Buildings.Add(building);
            _context.SaveChanges();
        }

        public void UpdateBuilding(Building building)
        {
            var existingBuilding = _context.Buildings.FirstOrDefault(b => b.BuildingId == building.BuildingId);
            if (existingBuilding != null)
            {
                existingBuilding.Name = building.Name;
                existingBuilding.Address = building.Address;
                existingBuilding.Description = building.Description;
                existingBuilding.Location = building.Location;

                // Handle associated rooms (optional, depending on your use case)
                if (building.Rooms != null && building.Rooms.Count > 0)
                {
                    existingBuilding.Rooms = building.Rooms;
                }

                _context.SaveChanges();
            }
        }

        public void DeleteBuilding(string buildingId)
        {
            //var building = _context.Buildings.Include(b => b.Rooms).FirstOrDefault(b => b.BuildingId == buildingId);
            //if (building != null)
            //{
            //    if (building.Rooms != null && building.Rooms.Count > 0)
            //    {
            //        _context.Rooms.RemoveRange(building.Rooms);
            //    }

            //    _context.Buildings.Remove(building);
            //    _context.SaveChanges();
            //}
            if (string.IsNullOrEmpty(buildingId))
                throw new ArgumentException("Building ID cannot be null or empty.", nameof(buildingId));

            var building = _context.Buildings.Include(b => b.Rooms)
                .FirstOrDefault(b => b.BuildingId == buildingId);

            if (building == null)
                throw new KeyNotFoundException($"Building with ID '{buildingId}' not found.");

            // Mark building and its rooms as invisible
            building.IsVisible = false;
            foreach (var room in building.Rooms)
            {
                room.IsVisible = false;
            }

            _context.SaveChanges();
        }
    }
}
