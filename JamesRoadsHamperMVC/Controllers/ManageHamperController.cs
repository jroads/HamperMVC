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
    public class ManageHamperController : Controller
    {
        private IDataService<Hamper> _hamperService;
        public ManageHamperController(IDataService<Hamper> hamperService)
        {
            _hamperService = hamperService;
        }
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public IActionResult AddHamper()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddHamper(AddHamperViewModel vm)
        {
            if (ModelState.IsValid)
            {
                //map
                Hamper hamper = new Hamper
                {
                    Name = vm.Name,
                    Category = vm.Category,
                    Details = vm.Details,
                    Price = vm.Price
                };
                //save into db
                _hamperService.Create(hamper);
                //go to store page
                return RedirectToAction("Shop", "Shop");
            }


            return View(vm);
        }
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public IActionResult EditHamper()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EditHamper(EditHamperViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Hamper hamper = new Hamper
                {
                    HamperId = vm.HamperId,
                    Name = vm.Name,
                    Category = vm.Category,
                    Details = vm.Details,
                    Price = vm.Price
                };
                _hamperService.Update(hamper);
                return RedirectToAction("Shop", "Shop");
            }
            return View(vm);
        }
    }
}