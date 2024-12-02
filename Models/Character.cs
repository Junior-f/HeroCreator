using System.ComponentModel.DataAnnotations;
using System;

namespace HeroCreator.Models
{
    public class Character
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; } 
        public string Class { get; set; } 
        public List<string> Inventory { get; set; } 
        public string Attributes { get; set; }
        public int Level { get; set; } 
    
    }
}