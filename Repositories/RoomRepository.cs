using BusinessObjects;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly RoomDAO _roomDAO;
        private PodBookingSystemContext _context;
        public RoomRepository()
        {
            _context = new PodBookingSystemContext();
            _roomDAO = new RoomDAO(_context);
        }

        public List<Room> GetAllRooms()
        {
            //return _roomDAO.GetAllRooms();
            return _context.Rooms.Include(r => r.Type).Include(r => r.Building)
                .Where(r => r.IsVisible) // Filter for visible rooms
                .ToList();
        }

        public Room GetRoomById(string roomId)
        {
           // return _roomDAO.GetRoomById(roomId);
            var room = _roomDAO.GetRoomById(roomId);
            if (room == null || !room.IsVisible) // Ensure the room is visible
            {
                return null; // Return null if the room is not found or not visible
            }
            return room;
        }

        public void AddRoom(Room room)
        {
            _roomDAO.AddRoom(room);
        }

        public void UpdateRoom(Room room)
        {
            _roomDAO.UpdateRoom(room);
        }

        public void DeleteRoom(string roomId)
        {
            _roomDAO.DeleteRoom(roomId);
        }
    }
}
