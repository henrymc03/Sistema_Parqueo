using System;
using System.Collections.Generic;

namespace SmartParkingCR_Backend.Models;

public partial class Vehicle
{

    private int idVehicle;
    private string licensePlate;
    private string color;
    private int weight;
    private string brand;
    private VehicleType type;
    private User user;
    public Vehicle()
    {
    }

    public Vehicle(int idVehicle, string licensePlate, string color, int weight, string brand, VehicleType type)
    {
        this.idVehicle = idVehicle;
        this.licensePlate = licensePlate;
        this.color = color;
        this.weight = weight;
        this.brand = brand;
        this.type = type;
    }

    public Vehicle(int idVehicle, string licensePlate, string color, int weight, string brand, VehicleType type, User user)
    {
        this.idVehicle = idVehicle;
        this.licensePlate = licensePlate;
        this.color = color;
        this.weight = weight;
        this.brand = brand;
        this.type = type;
        this.User = user;
    }

    public int IdVehicle { get => idVehicle; set => idVehicle = value; }
    public string LicensePlate { get => licensePlate; set => licensePlate = value; }
    public string Color { get => color; set => color = value; }
    public int Weight { get => weight; set => weight = value; }
    public string Brand { get => brand; set => brand = value; }
    public VehicleType Type { get => type; set => type = value; }
    public User User { get => user; set => user = value; }
}
