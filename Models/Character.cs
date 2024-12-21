using System.ComponentModel.DataAnnotations;
using System;

namespace HeroCreator.Models
{
    public class Character
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Name { get; set; }
        [Required]
        public string Class { get; set; }
        [Required]
        public string Inventory { get; set; }
        [Required]
        public string Attributes { get; set; }
        [Required]
        [Range(1, 100, ErrorMessage = "Level must be between 1 and 100.")]
        public int Level { get; set; }
    }
}