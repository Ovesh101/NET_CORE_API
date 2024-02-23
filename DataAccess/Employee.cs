using System;
using System.Collections.Generic;

namespace NET_Core_CRUD_API.DataAccess;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Contact { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public string DepartmentName { get; set; } = null!;
}
