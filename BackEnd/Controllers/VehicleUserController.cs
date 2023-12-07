using Microsoft.AspNetCore.Mvc;
using Proyecto1_Lenguajes.Models;
using Proyecto1_Lenguajes.Models.Data;
using Proyecto1_Lenguajes.Models.Domain;
using System.Diagnostics;

namespace Proyecto1_Lenguajes.Controllers
{
    public class VehicleUserController : Controller
    {
      
        private readonly IConfiguration _configuration;
        VehicleUserDAO vehicleUserDAO;

        public VehicleUserController( IConfiguration configuration)
        {
           
            _configuration = configuration;
            vehicleUserDAO = new VehicleUserDAO(_configuration);
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        [Route("api/vehicle/[action]/id")]
        public IActionResult GetByEmail(int id)
        {
            try
            {
                return Ok(vehicleUserDAO.GetByUserId(id));
            }
            catch (Exception)
            {
                return Error();
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
