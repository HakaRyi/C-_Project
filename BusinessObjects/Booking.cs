using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Booking
{
    public string BookingId { get; set; } = null!;

    public DateOnly? BookingDate { get; set; }

    public string? Status { get; set; }

    public double Total { get; set; }

    public string? UserId { get; set; }


    public virtual ICollection<BookingDetail> BookingDetails { get; set; } = new List<BookingDetail>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<RoomSlot> RoomSlots { get; set; } = new List<RoomSlot>();

    public virtual User? User { get; set; }
}
