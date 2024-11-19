using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookingDetailService : IBookingDetailService
    {
        private readonly IBookingDetailRepository repository;
        public BookingDetailService()
        {
            repository = new BookingDetailRepository();
        }
        public void AddBookingDetail(BookingDetail bookingDetail)
        {
           repository.AddBookingDetail(bookingDetail);
        }

        public List<BookingDetail> GetAll()
        {
            return repository.GetAll();
        }

        public List<BookingDetail> GetAllByBooking(string bookingId)
        {
            return repository.GetAllByBooking(bookingId);
        }

        public void UpdateBookingDetail(BookingDetail bookingDetail)
        {
            repository.UpdateBookingDetail(bookingDetail);
        }
    }
}
