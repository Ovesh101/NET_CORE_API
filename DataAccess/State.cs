using System;
using System.Collections.Generic;

namespace NET_Core_CRUD_API.DataAccess;

public partial class State
{
    public int StateId { get; set; }

    public string? StateName { get; set; }

    public virtual ICollection<City> Cities { get; set; } = new List<City>();
}
