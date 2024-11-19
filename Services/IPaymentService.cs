﻿using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IPaymentService
    {
        public void AddPayment(Payment payment);
        public List<Payment> GetPaymentByBooking(string bookingId);

        public List<Payment> GetPayments();
    }
}
