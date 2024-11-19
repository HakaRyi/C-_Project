using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IBookingService
    {
        public void AddBooking(Booking booking);
        public List<Booking> GetBookingByUser(string userId);
        public Booking GetBookingById(string bookingId);
        public void UpdateBooking(Booking booking);
        public List<Booking> GetBooking();
    }
}
