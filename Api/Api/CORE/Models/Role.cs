﻿using System.ComponentModel.DataAnnotations;

namespace Api.CORE.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
    }
}
