using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private PodBookingSystemContext db;
        public void AddBooking(Booking booking)
        {
            db = new();
            db.Entry(booking.User).State = EntityState.Unchanged;
            db.Bookings.Add(booking);
            db.SaveChanges();
        }

        public Booking GetBookingById(string bookingId)
        {
            db = new();
            var result = db.Bookings.FirstOrDefault(booking => booking.BookingId.Equals(bookingId));
            return result;
        }

        public List<Booking> GetBookingByUser(string userId)
        {
            db = new();
            var result = db.Bookings.Where(booking => booking.UserId.Equals(userId)).ToList();
            return result;
        }

        public void UpdateBooking(Booking booking)
        {
            db = new();
            var book = db.Bookings.FirstOrDefault(r => r.BookingId == booking.BookingId);
            if (book != null)
            {
                book.Status = booking.Status;
                db.SaveChanges();
            }
        }

        public List<Booking> GetBookings()
        {
            db = new();
            var result = db.Bookings.ToList();
            return result;
        }
    }
}

