using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JamesRoadsHamperMVC.Models
{
    public class Hamper
    {
        public int HamperId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Details { get; set; }
        public double Price { get; set; }
    }
}
