using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects;

public partial class RoomSlot
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string UId { get; set; } = null!;

    public DateOnly? BookingDate { get; set; }

    public string? BookingId { get; set; }

    public string? RoomId { get; set; }

    public string? SlotId { get; set; }

    public virtual Booking? Booking { get; set; }

    public virtual Room? Room { get; set; }

}
