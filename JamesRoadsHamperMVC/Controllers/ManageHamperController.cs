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
using Microsoft.AspNetCore.Http;
using System.IO;

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
        public IActionResult EditHamper(int id)
        {
            Hamper hamper = _hamperService.GetSingle(h => h.HamperId == id);
            EditHamperViewModel vm = new EditHamperViewModel
            {
                HamperId = hamper.HamperId,
                Name = hamper.Name,
                Category = hamper.Category,
                Details = hamper.Details,
                Price = hamper.Price
            };
            return View(vm);
        }
        [HttpPost]
        public IActionResult EditHamper(EditHamperViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Hamper updatedHamper = new Hamper
                {
                    HamperId = vm.HamperId,
                    Name = vm.Name,
                    Category = vm.Category,
                    Details = vm.Details,
                    Price = vm.Price
                };
                //save
                _hamperService.Update(updatedHamper);
                //go back to shop
                return RedirectToAction("Shop", "Shop");
            }
            return View(vm);
        }
    }
}