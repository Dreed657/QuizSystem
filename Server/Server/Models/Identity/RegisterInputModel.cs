﻿using System.ComponentModel.DataAnnotations;

namespace Server.Models.Identity
{
    public class RegisterInputModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
