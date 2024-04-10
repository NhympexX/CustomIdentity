﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CustomIdentity.Models
{
    public class AppUser : IdentityUser
    {
        [MaxLength(100)]
        [StringLength(100)]
        [Required]
        public string? Name { get; set; }
        public string? Adress { get; set; }
    }
}
