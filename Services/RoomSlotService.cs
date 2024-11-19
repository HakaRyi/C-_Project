using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RoomSlotService
    {
        RoomSlotRepository repository;
        public RoomSlotService()
        {
            repository = new RoomSlotRepository();
        }
        public void AddRoomSlot(RoomSlot roomSlot) => repository.AddRoomSlot(roomSlot);

        public List<RoomSlot> GetRoomBookedSlots(string roomId) => repository.GetRoomBookedSlots(roomId);
    }
}
