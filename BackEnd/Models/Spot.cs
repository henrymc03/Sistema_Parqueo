using System;
using System.Collections.Generic;

namespace SmartParkingCR_Backend.Models;

public partial class Spot
{
    private int id;
    private int number;
    private string type;
    private string status;
    private Vehicle vehicle;
    private ParkingLot parkingLot;

    public Spot()
    {
        vehicle = new Vehicle();
        parkingLot = new ParkingLot();
    }

    public Spot(int id, int number, string type, string status, Vehicle vehicle, ParkingLot parkingLot)
    {
        this.id = id;
        this.number = number;
        this.type = type;
        this.status = status;
        this.vehicle = vehicle;
        this.parkingLot = parkingLot;
    }

    public int Number { get => number; set => number = value; }
    public string Type { get => type; set => type = value; }
    public string Status { get => status; set => status = value; }
    public Vehicle Vehicle { get => vehicle; set => vehicle = value; }
    public ParkingLot ParkingLot { get => parkingLot; set => parkingLot = value; }
    public int Id { get => id; set => id = value; }
}
