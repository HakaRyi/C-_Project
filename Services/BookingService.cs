using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository repository;
        public BookingService()
        {
            repository = new BookingRepository();
        }
        public void AddBooking(Booking booking)
        {
           repository.AddBooking(booking);
        }

        public List<Booking> GetBooking()
        {
            return repository.GetBookings();
        }

        public Booking GetBookingById(string bookingId)
        {
            return repository.GetBookingById(bookingId);
        }

        public List<Booking> GetBookingByUser(string userId)
        {
           return repository.GetBookingByUser(userId);
        }

        public void UpdateBooking(Booking booking)
        {
            repository.UpdateBooking(booking);
        }
    }
}
