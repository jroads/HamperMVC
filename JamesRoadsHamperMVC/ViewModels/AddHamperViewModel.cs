using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JamesRoadsHamperMVC.ViewModels
{
    public class AddHamperViewModel
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Details { get; set; }
        public double Price { get; set; }
    }
}
