using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class User
{
    public string UseridId { get; set; } = null!;

    public string? Email { get; set; }

    public string? Name { get; set; }

    public string? Password { get; set; }

    public string? Phone { get; set; }

    public string? Username { get; set; }

    public string RoleId { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Role Role { get; set; } = null!;
}
