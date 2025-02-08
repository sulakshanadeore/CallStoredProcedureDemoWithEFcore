using System;
using System.Collections.Generic;

namespace CallStoredProcedureDemo.Models;

public partial class Passenger
{
    public int SeatNo { get; set; }

    public string? SeatType { get; set; }

    public int? FlightNo { get; set; }

    public string? StartingPoint { get; set; }

    public string? Destination { get; set; }
}
