using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IPaymentDetailRepo
    {
        public void AddPaymentDetail(PaymentDetail paymentDetail);
        public List<PaymentDetail> GetAllByPayment(string paymentId);

        public List<PaymentDetail> GetAll();
    }
}
