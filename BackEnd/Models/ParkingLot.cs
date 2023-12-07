using System;
using System.Collections.Generic;

namespace SmartParkingCR_Backend.Models;

public partial class ParkingLot
{
    public int IdParkingLot { get; set; }

    public string Name { get; set; } = null!;

    public int CapacitySize { get; set; }

    public string Province { get; set; } = null!;

    public string City { get; set; } = null!;

    public string District { get; set; } = null!;

    public virtual ICollection<User> Users { get; } = new List<User>();



    public ParkingLot()
    {

    }
    public ParkingLot(int idParking, string name, int capacity, string province, string city, string district)
    {
        this.IdParkingLot = idParking;
        this.Name = name;
        this.CapacitySize = capacity;
        this.Province = province;
        this.City = city;
        this.District = district;
    }

 
}
