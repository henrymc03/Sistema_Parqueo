using System;
using System.Collections.Generic;

namespace SmartParkingCR_Backend.Models;

public partial class User
{
    public int IdUser { get; set; }

    public string Identification { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? TelNumber { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int RoleId { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; } = new List<Ticket>();

    public virtual ICollection<ParkingLot> ParkingLots { get; } = new List<ParkingLot>();

    public virtual ICollection<Vehicle> Vehicles { get; } = new List<Vehicle>();


    public User()
    {
        this.Role = new Role();
    }

    public User(int id_User, string identification, string name, string lastname, string tel_Number, string email, string password, Role role)
    {
        this.IdUser = id_User;
        this.Identification = identification;
        this.Name = name;
        this.LastName = lastname;
        this.TelNumber = tel_Number;
        this.Email = email;
        this.Password = password;
        this.Role = role;
    }
}
