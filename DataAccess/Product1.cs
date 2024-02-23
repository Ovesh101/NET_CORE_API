using System;
using System.Collections.Generic;

namespace NET_Core_CRUD_API.DataAccess;

public partial class Product1
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public int? StockQuantity { get; set; }

    public bool? Available { get; set; }

    public string? ProductGenre { get; set; }

    public string? ProductState { get; set; }
}
