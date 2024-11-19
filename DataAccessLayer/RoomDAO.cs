using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class RoomDAO
    {
        private readonly PodBookingSystemContext _context;

        public RoomDAO(PodBookingSystemContext context)
        {
            _context = context;
        }

        public List<Room> GetAllRooms()
        {
            return _context.Rooms.Include(x => x.Type).ToList();
        }

        public Room GetRoomById(string roomId)
        {
            return _context.Rooms.FirstOrDefault(r => r.RoomId == roomId);
        }

        public void AddRoom(Room room)
        {
            _context.Rooms.Add(room);
            _context.SaveChanges();
        }

        public void UpdateRoom(Room room)
        {
            var existingRoom = _context.Rooms.FirstOrDefault(r => r.RoomId == room.RoomId);
            if (existingRoom != null)
            {
                existingRoom.Availability = room.Availability;
                existingRoom.AvailebleDate = room.AvailebleDate;
                existingRoom.Capacity = room.Capacity;
                existingRoom.Description = room.Description;
                existingRoom.Name = room.Name;
                existingRoom.Price = room.Price;
                existingRoom.BuildingId = room.BuildingId;
                existingRoom.TypeId = room.TypeId;
                _context.SaveChanges();
            }
        }

        public void DeleteRoom(string roomId)
        {
            //var room = _context.Rooms.FirstOrDefault(r => r.RoomId == roomId);
            //if (room != null)
            //{
            //    _context.Rooms.Remove(room);
            //    _context.SaveChanges();
            //}
            if (string.IsNullOrEmpty(roomId))
                throw new ArgumentException("Room ID cannot be null or empty.", nameof(roomId));

            var room = _context.Rooms.FirstOrDefault(r => r.RoomId == roomId);

            if (room == null)
                throw new KeyNotFoundException($"Room with ID '{roomId}' not found.");

            // Mark room as invisible
            room.IsVisible = false;

            _context.SaveChanges();
        }
    }
}
