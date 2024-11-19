using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Slot
{
    public string SlotId { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<RoomSlot> RoomSlots { get; set; } = new List<RoomSlot>();
}
