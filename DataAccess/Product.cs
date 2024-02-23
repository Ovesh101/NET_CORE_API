using System;
using System.Collections.Generic;

namespace NET_Core_CRUD_API.DataAccess;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public int Quantity { get; set; }

    public int Price { get; set; }

    public DateOnly? LastUpdated { get; set; }
}
