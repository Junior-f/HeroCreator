using System.ComponentModel.DataAnnotations;
using System;

namespace HeroCreator.ViewModels
{
    public class CreateCharacterViewModel
    {
        public string Name { get; set; }
        public string Class { get; set; }
        public string Inventory { get; set; }
        public string Attributes { get; set; }
        public int Level { get; set; }
    }
}