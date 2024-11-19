using BusinessObjects;
using System.Collections.Generic;

namespace Repositories
{
    public interface IBuildingRepository
    {
        List<Building> GetAllBuildings();
        Building GetBuildingById(string buildingId);
        void AddBuilding(Building building);
        void UpdateBuilding(Building building);
        void DeleteBuilding(string buildingId);
    }
}
