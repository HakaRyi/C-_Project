using BusinessObjects;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Repositories
{
    public class BuildingRepository : IBuildingRepository
    {
        private readonly BuildingDAO _buildingDAO;
        private PodBookingSystemContext _context;

        public BuildingRepository()
        {
            _context = new PodBookingSystemContext();
            _buildingDAO = new BuildingDAO(_context);
        }

        public List<Building> GetAllBuildings()
        {
            //return _buildingDAO.GetAllBuildings();
            return _context.Buildings.Include(b => b.Rooms)
                .Where(b => b.IsVisible) // Filter for visible buildings
                .ToList();
        }

        public Building GetBuildingById(string buildingId)
        {
            //return _buildingDAO.GetBuildingById(buildingId);
            var building = _buildingDAO.GetBuildingById(buildingId);
            if (building == null || !building.IsVisible) // Ensure the building is visible
            {
                return null; // Return null if building is not found or not visible
            }
            return building;
        }

        public void AddBuilding(Building building)
        {
            _buildingDAO.AddBuilding(building);
        }

        public void UpdateBuilding(Building building)
        {
            _buildingDAO.UpdateBuilding(building);
        }

        public void DeleteBuilding(string buildingId)
        {
            _buildingDAO.DeleteBuilding(buildingId);
        }
    }
}
