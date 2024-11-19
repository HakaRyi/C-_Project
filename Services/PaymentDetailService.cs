using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PaymentDetailService : IPaymentDetailService
    {
        private readonly IPaymentDetailRepo repo;
        public PaymentDetailService()
        {
            repo= new PaymentDetailRepo();  
        }
        public void AddPaymentDetail(PaymentDetail paymentDetail)
        {
            repo.AddPaymentDetail(paymentDetail);
        }

        public List<PaymentDetail> GetAllByPayment(string paymentId)
        {
            return repo.GetAllByPayment(paymentId);
        }

        public List<PaymentDetail> GetPaymentDetails()
        {
            return repo.GetAll();
        }
    }
}
