using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IPaymentDetailService
    {
        public void AddPaymentDetail(PaymentDetail paymentDetail);
        public List<PaymentDetail> GetAllByPayment(string paymentId);

        public List<PaymentDetail> GetPaymentDetails();
    }
}
