using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepo repository;
        public PaymentService()
        {
            repository=new PaymentRepo();
        }
        public void AddPayment(Payment payment)
        {
            repository.AddPayment(payment);
        }

        public List<Payment> GetPaymentByBooking(string bookingId)
        {
            return repository.GetPaymentByBooking(bookingId);
        }

        
        public List<Payment> GetPayments()
        {
            return repository.GetPayments();
        }
    }
}
