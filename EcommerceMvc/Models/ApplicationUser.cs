﻿using Microsoft.AspNetCore.Identity;

namespace EcommerceMvc.Models;

public class ApplicationUser : IdentityUser
{
    public ICollection<Order>? Orders { get; set; }
}