using BusinessObjects;
using Repositories;
using System.Collections.Generic;

namespace Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService()
        {
            _roomRepository = new RoomRepository();
        }

        public List<Room> GetAllRooms()
        {
            return _roomRepository.GetAllRooms();
        }

        public Room GetRoomById(string roomId)
        {
            //return _roomRepository.GetRoomById(roomId);
            var room = _roomRepository.GetRoomById(roomId);
            if (room == null || !room.IsVisible) // Ensure the room is visible
            {
                return null; // Return null if the room is not found or not visible
            }
            return room;
        }

        public void AddRoom(Room room)
        {
            _roomRepository.AddRoom(room);
        }

        public void UpdateRoom(Room room)
        {
            _roomRepository.UpdateRoom(room);
        }

        public void DeleteRoom(string roomId)
        {
            _roomRepository.DeleteRoom(roomId);
        }
    }
}
