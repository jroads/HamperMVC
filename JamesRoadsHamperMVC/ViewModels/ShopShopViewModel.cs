using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JamesRoadsHamperMVC.Models;

namespace JamesRoadsHamperMVC.ViewModels
{
    public class ShopShopViewModel
    {
        public int Total { get; set; }
        public IEnumerable<Hamper> Hampers { get; set; }
        public string Category { get; set; }
        public string ImgUrl { get; set; }
    }
}
