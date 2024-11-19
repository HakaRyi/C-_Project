using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BookingDetailRepository : IBookingDetailRepository
    {
        private PodBookingSystemContext db;
        public BookingDetailRepository()
        {
            db = new PodBookingSystemContext();
        }
        public void AddBookingDetail(BookingDetail bookingDetail)
        {
            if (bookingDetail.Booking == null || bookingDetail.Room == null || bookingDetail.Room.Type == null)
            {
                throw new ArgumentException("Booking, Room, and Room.Type must be non-null.");
            }


            db.Entry(bookingDetail.Booking).State = EntityState.Unchanged;
            db.Entry(bookingDetail.Room).State = EntityState.Unchanged;
            db.Entry(bookingDetail.Room.Type).State = EntityState.Unchanged;
            db.BookingDetails.Add(bookingDetail);
            db.SaveChanges();
        }

        public List<BookingDetail> GetAll()
        {
            db = new();
            var result = db.BookingDetails.ToList();
            return result;
        }

        public List<BookingDetail> GetAllByBooking(string bookingId)
        {
            db = new();
            var result = db.BookingDetails.Where(x => x.BookingId == bookingId).ToList();
            return result;
        }

        public void UpdateBookingDetail(BookingDetail bookingDetail)
        {
            db=new();
            var bookDetail = db.BookingDetails.FirstOrDefault(r => r.BookingDetailId == bookingDetail.BookingDetailId);
            if (bookDetail != null)
            {
                bookDetail.Status = bookingDetail.Status;
                db.SaveChanges();
            }
        }
    }
}
