using System.ComponentModel.DataAnnotations;
using System;

namespace HeroCreator.ViewModels
{
    public class CharacterViewModel
    {
        public String? Name { get; set; }
        public String? Class { get; set; }
        public String? Inventory { get; set; }
        public String? Attributes { get; set; }
        public int Level { get; set; }
    }
}