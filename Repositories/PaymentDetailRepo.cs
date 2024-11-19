using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class PaymentDetailRepo : IPaymentDetailRepo
    {
        private PodBookingSystemContext db;
        public PaymentDetailRepo()
        {
            db=new PodBookingSystemContext();
        }
        public void AddPaymentDetail(PaymentDetail paymentDetail)
        {
            if (paymentDetail.Payment == null || paymentDetail.Room == null)
            {
                throw new ArgumentException("Payment, Room must be non-null.");
            }
            db.Entry(paymentDetail.Payment).State = EntityState.Unchanged;
            db.Entry(paymentDetail.Room).State = EntityState.Unchanged;
            //db.Entry(paymentDetail.Room.Type).State = EntityState.Unchanged;
            db.PaymentDetails.Add(paymentDetail);
            db.SaveChanges();
        }

        public List<PaymentDetail> GetAll()
        {
            db = new();
            var result = db.PaymentDetails.ToList();
            return result;
        }

        public List<PaymentDetail> GetAllByPayment(string paymentId)
        {
            db = new();
            var result = db.PaymentDetails.Where(x => x.PaymentId == paymentId).ToList();
            return result;
        }
    }
}
