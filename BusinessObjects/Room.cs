using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Room
{
    public string RoomId { get; set; } = null!;

    public string? Availability { get; set; }

    public DateOnly? AvailebleDate { get; set; }

    public int Capacity { get; set; }

    public string? Description { get; set; }

    public string? Name { get; set; }

    public double Price { get; set; }

    public string? BuildingId { get; set; }

    public string? TypeId { get; set; }

    public bool IsVisible { get; set; } = true;

    public virtual ICollection<BookingDetail> BookingDetails { get; set; } = new List<BookingDetail>();

    public virtual Building? Building { get; set; }

    public virtual ICollection<PaymentDetail> PaymentDetails { get; set; } = new List<PaymentDetail>();

    public virtual ICollection<RoomSlot> RoomSlots { get; set; } = new List<RoomSlot>();

    public virtual RoomType? Type { get; set; }
}
