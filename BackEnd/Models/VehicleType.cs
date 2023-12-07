using System;
using System.Collections.Generic;

namespace SmartParkingCR_Backend.Models;

public partial class VehicleType
{
    public int IdType { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Rate> Rates { get; } = new List<Rate>();

    public virtual ICollection<Vehicle> Vehicles { get; } = new List<Vehicle>();
    public VehicleType()
    {
    }

    public VehicleType(int id_Type, string name)
    {
        this.IdType = id_Type;
        this.Name = name;
    }

}
