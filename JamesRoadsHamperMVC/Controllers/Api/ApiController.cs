using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using JamesRoadsHamperMVC.Models;
using JamesRoadsHamperMVC.Services;
using System.Linq;

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
            IEnumerable<Hamper> hamperList = _hamperDataService.GetAll();
            return hamperList;
        }
        [HttpGet("{Category}")]
        public Hamper Get(string Category)
        {
            IEnumerable<Hamper> hamperList = _hamperDataService.GetAll();
            return hamperList.Where(c => c.Category == Category).FirstOrDefault();
        }
    }
}