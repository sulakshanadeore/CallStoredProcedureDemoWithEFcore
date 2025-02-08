using System;
using System.Collections.Generic;

namespace CallStoredProcedureDemo.Models;

public partial class Customer
{
    public int Custid { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? City { get; set; }

    public string? Mobile { get; set; }
}
