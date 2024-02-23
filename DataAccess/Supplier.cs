using System;
using System.Collections.Generic;

namespace NET_Core_CRUD_API.DataAccess;

public partial class Supplier
{
    public int SupplierId { get; set; }

    public string? SupplierName { get; set; }

    public string? Email { get; set; }

    public string? ContactPerson { get; set; }

    public int? PhoneNumber { get; set; }
}
