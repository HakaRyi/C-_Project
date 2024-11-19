using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class RoomType
{
    public string TypeId { get; set; } = null!;

    public string? Name { get; set; }

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
