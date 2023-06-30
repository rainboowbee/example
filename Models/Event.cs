using System;
using System.Collections.Generic;

namespace laba6.Models;

public partial class Event
{
    public int Id { get; set; }

    public string? EventName { get; set; }

    public string? VenueName { get; set; }

    public string? City { get; set; }

    public string? Street { get; set; }

    public int? TicketQuantity { get; set; }

    public int? TicketPrice { get; set; }
}
