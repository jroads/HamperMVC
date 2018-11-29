using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using JamesRoadsHamperMVC.Models;
using JamesRoadsHamperMVC.Services;

namespace JamesRoadsHamperMVC.Controllers.Api
{
    [Route("api/hampers")]
    [ApiController]
    public class ApiController : Controller
    {
        private IDataService<Hamper> _hamperDataService;
        public ApiController(IDataService<Hamper> hamperService)
        {
            _hamperDataService = hamperService;
        }
        [HttpGet]
        public IEnumerable<Hamper> Get()
        {
            IEnumerable<Hamper> hampers = _hamperDataService.GetAll();
            Hamper h = new Hamper
            {
                 
            };
            return hampers;
        }


    }
}