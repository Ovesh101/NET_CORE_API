using System;
using System.Collections.Generic;

namespace NET_Core_CRUD_API.DataAccess;

public partial class Order
{
    public int OrderId { get; set; }

    public int? CustomerId { get; set; }

    public DateOnly? OrderDate { get; set; }

    public decimal Amount { get; set; }

    public bool? PaymentStatus { get; set; }

    public virtual Customer? Customer { get; set; }
}
