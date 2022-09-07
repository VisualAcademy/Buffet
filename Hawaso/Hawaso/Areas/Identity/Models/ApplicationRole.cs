﻿using Microsoft.AspNetCore.Identity;

namespace Hawaso.Areas.Identity.Models
{
    public class ApplicationRole : IdentityRole
    {
        public string? Description { get; set; }
    }
}
