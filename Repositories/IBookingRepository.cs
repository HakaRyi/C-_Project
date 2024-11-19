using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IBookingRepository
    {
        public void AddBooking(Booking booking);
        public List<Booking> GetBookingByUser(string userId);
        public Booking GetBookingById(string bookingId);
        public void UpdateBooking(Booking booking);
        public List<Booking> GetBookings();
    }
}
