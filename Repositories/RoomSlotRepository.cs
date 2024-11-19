using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RoomSlotRepository
    {
        private PodBookingSystemContext db;
        public void AddRoomSlot(RoomSlot roomSlot)
        {
            db = new();
            db.Entry(roomSlot.Booking).State = EntityState.Unchanged;
            db.Entry(roomSlot.Room).State = EntityState.Unchanged;
            db.Entry(roomSlot.Room.Type).State = EntityState.Unchanged;
            db.RoomSlots.Add(roomSlot);
            db.SaveChanges();
        }

        public List<RoomSlot> GetRoomBookedSlots(string roomId)
        {
            db = new();
            var result = db.RoomSlots.Where(x => x.RoomId == roomId).ToList();
            return result;
        }
    }
}
