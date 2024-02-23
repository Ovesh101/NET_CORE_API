﻿using System;
using System.Collections.Generic;

namespace NET_Core_CRUD_API.DataAccess;

public partial class City
{
    public int CityId { get; set; }

    public string? CityName { get; set; }

    public int? StateId { get; set; }

    public virtual State? State { get; set; }
}
