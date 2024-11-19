using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class PaymentRepo : IPaymentRepo
    {
        private PodBookingSystemContext db;
        public void AddPayment(Payment payment)
        {
            db = new();
            db.Entry(payment.Booking).State = EntityState.Unchanged;
            db.Payments.Add(payment);
            db.SaveChanges();
        }

        public List<Payment> GetPaymentByBooking(string bookingId)
        {
            db = new();
            var result = db.Payments.Where(payment => payment.BookingId.Equals(bookingId)).ToList();
            return result;
        }

        public List<Payment> GetPayments()
        {
            db = new();
            var result = db.Payments.ToList();
            return result;
        }
    }
}
