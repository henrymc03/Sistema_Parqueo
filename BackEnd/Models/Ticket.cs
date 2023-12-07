using System;
using System.Collections.Generic;

namespace SmartParkingCR_Backend.Models;

public partial class Ticket
{
    private int idTicket;
    private ParkingLot parkingLot;
    private Spot spot;
    private User user;
    private RateType rateType;
    private string starDay;
    private string endDay;

    public Ticket()
    {
        parkingLot = new ParkingLot();
        spot = new Spot();
        user = new User();
        rateType = new RateType();
    }

    public Ticket(int idTicket, ParkingLot parkingLot, Spot spot, User user, RateType rateType, string starDay, string endDay)
    {
        this.idTicket = idTicket;
        this.parkingLot = parkingLot;
        this.spot = spot;
        this.user = user;
        this.rateType = rateType;
        this.starDay = starDay;
        this.endDay = endDay;
    }

    public int IdTicket { get => idTicket; set => idTicket = value; }
    public ParkingLot ParkingLot { get => parkingLot; set => parkingLot = value; }
    public Spot Spot { get => spot; set => spot = value; }
    public User User { get => user; set => user = value; }
    public RateType RateType { get => rateType; set => rateType = value; }
    public string StarDay { get => starDay; set => starDay = value; }
    public string EndDay { get => endDay; set => endDay = value; }
}
