using System;
using System.Collections.Generic;

namespace SmartParkingCR_Backend.Models;

public partial class Role
{
    public int IdRole { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<User> Users { get; } = new List<User>();

    public Role()
    {
    }

    public Role(int id_Role, string name)
    {
        this.IdRole = id_Role;
        this.Name = name;
    }
}
