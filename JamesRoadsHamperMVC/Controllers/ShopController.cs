using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//...
using Microsoft.AspNetCore.Identity;
using JamesRoadsHamperMVC.Models;
using JamesRoadsHamperMVC.ViewModels;
using JamesRoadsHamperMVC.Services;
using Microsoft.AspNetCore.Authorization;

namespace JamesRoadsHamperMVC.Controllers
{
    public class ShopController : Controller
    {
        private IDataService<Hamper> _hamperService;
        public ShopController(IDataService<Hamper> hamperService)
        {
            _hamperService = hamperService;
        }
        [HttpGet]
        public IActionResult Shop()
        {
            //call service
            IEnumerable<Hamper> hamperList = _hamperService.GetAll();

            //create VM
            ShopShopViewModel vm = new ShopShopViewModel
            {
                Hampers = hamperList,

            };

            return View();
        }
        
    }
}