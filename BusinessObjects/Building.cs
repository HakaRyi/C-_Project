using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Building
{
    public string BuildingId { get; set; } = null!;

    public string? Address { get; set; }

    public string? Description { get; set; }

    public string? Location { get; set; }

    public string? Name { get; set; }

    public bool IsVisible { get; set; } = true;

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
