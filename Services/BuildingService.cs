using BusinessObjects;
using Repositories;
using System.Collections.Generic;

namespace Services
{
    public class BuildingService : IBuildingService
    {
        private readonly IBuildingRepository _buildingRepository;

        public BuildingService()
        {
            _buildingRepository = new BuildingRepository();
        }

        public List<Building> GetAllBuildings()
        {
            return _buildingRepository.GetAllBuildings();
        }

        public Building GetBuildingById(string buildingId)
        {
            //return _buildingRepository.GetBuildingById(buildingId);
            var building = _buildingRepository.GetBuildingById(buildingId);
            if (building == null || !building.IsVisible) // Ensure the building is visible
            {
                return null; // Return null if the building is not found or not visible
            }
            return building;
        }

        public void AddBuilding(Building building)
        {
            _buildingRepository.AddBuilding(building);
        }

        public void UpdateBuilding(Building building)
        {
            _buildingRepository.UpdateBuilding(building);
        }

        public void DeleteBuilding(string buildingId)
        {
            _buildingRepository.DeleteBuilding(buildingId);
        }
    }
}
