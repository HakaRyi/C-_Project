using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Payment
{
    public string PaymentId { get; set; } = null!;

    public double TotalAmount { get; set; }

    public string BookingId { get; set; } = null!;

    public virtual Booking Booking { get; set; } = null!;

    public virtual ICollection<PaymentDetail> PaymentDetails { get; set; } = new List<PaymentDetail>();
}
