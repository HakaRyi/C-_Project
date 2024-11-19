using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects;

public partial class BookingDetail
{
    public string BookingDetailId { get; set; } = null!;
    [Column("end_time")]
    public DateOnly? EndTime { get; set; }

    public DateOnly? StartTime { get; set; }

    public string? Status { get; set; }

    public DateTime? Timestamp { get; set; }

    public double TotalPrice { get; set; }

    public string? BookingId { get; set; }
    [Column("room_id")]
    public string RoomId { get; set; } = null!;

    public virtual Booking? Booking { get; set; }

    public virtual Room Room { get; set; } = null!;
}
