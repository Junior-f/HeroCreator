using System.ComponentModel.DataAnnotations;
using System;

namespace HeroCreator.Models
{
    public class Character
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public String? Name { get; set; }
        [Required]
        public String? Class { get; set; }
        [Required]
        public String? Inventory { get; set; }
        [Required]
        public String? Attributes { get; set; }
        [Required]
        [Range(1, 100, ErrorMessage = "Level must be between 1 and 100.")]
        public int Level { get; set; }
    }
}