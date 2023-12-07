using System;
using System.Collections.Generic;

namespace SmartParkingCR_Backend.Models;

public partial class RateType
{
    public int IdRateType { get; set; }

    public string BookingTime { get; set; } = null!;

    public double Amount { get; set; }

    public virtual ICollection<Rate> Rates { get; } = new List<Rate>();

    public virtual ICollection<Ticket> Tickets { get; } = new List<Ticket>();

    public RateType()
    {
    }

    public RateType(int id_RateType, string booking_Time, float amount)
    {
        this.IdRateType = id_RateType;
        this.BookingTime = booking_Time;
        this.Amount = amount;
    }

}
