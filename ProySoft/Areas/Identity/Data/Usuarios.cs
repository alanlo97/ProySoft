using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ProySoft.Areas.Identity.Data;

// Add profile data for application users by adding properties to the Usuarios class
public class Usuarios : IdentityUser
{
    public string Name { get; set; }

    public int Dni { get; set; }

}

