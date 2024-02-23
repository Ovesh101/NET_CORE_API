using System;
using System.Collections.Generic;

namespace NET_Core_CRUD_API.DataAccess;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? CustomerName { get; set; }

    public short? Age { get; set; }

    public string? Email { get; set; }

    public int? PhoneNumber { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
