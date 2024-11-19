using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IBookingDetailRepository
    {
        public void AddBookingDetail (BookingDetail bookingDetail);
        public List<BookingDetail> GetAllByBooking (string bookingId);
        public void UpdateBookingDetail (BookingDetail bookingDetail);
        public List<BookingDetail> GetAll();
    }
}
