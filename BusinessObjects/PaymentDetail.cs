using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class PaymentDetail
{
    public string PaymentDetailId { get; set; } = null!;

    public DateTime? PaymentDate { get; set; }

    public string? PaymentId { get; set; }

    public string? PaymentMethod { get; set; }

    public string? PaymentStatus { get; set; }

    public double Price { get; set; }

    public string? RoomId { get; set; }

    public virtual Payment? Payment { get; set; }

    public virtual Room? Room { get; set; }
}
