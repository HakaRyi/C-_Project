using BusinessObjects;
using System.Collections.Generic;

namespace Services
{
    public interface IRoomService
    {
        List<Room> GetAllRooms();
        Room GetRoomById(string roomId);
        void AddRoom(Room room);
        void UpdateRoom(Room room);
        void DeleteRoom(string roomId);
    }
}
