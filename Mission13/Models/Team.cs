using System;
using System.ComponentModel.DataAnnotations;

namespace Mission13.Models
{
    public class Team
    {
        [Key]
        [Required]
        public int TeamId { get; set; }
        public string TeamName { get; set; }
    }
}
