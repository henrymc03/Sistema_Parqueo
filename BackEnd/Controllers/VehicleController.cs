using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto1_Lenguajes.Models;
using Proyecto1_Lenguajes.Models.Data;
using Proyecto1_Lenguajes.Models.Domain;
using SmartParkingCR_Backend.Models;
using System.Diagnostics;

namespace Proyecto1_Lenguajes.Controllers
{
    public class VehicleController : Controller
    {
      
        private readonly IConfiguration _configuration;
        VehicleDAO vehicleDAO;

        public VehicleController( IConfiguration configuration)
        {
            _configuration = configuration;
            //todo: instanciar studentDao solo una vez
            vehicleDAO = new VehicleDAO(_configuration);
        }



        // GET: VehicleController
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("api/vehicle/[action]")]
        public IActionResult Insert([FromBody] Vehicle vehicle)
        {
            if (vehicleDAO.Get(vehicle.LicensePlate).LicensePlate == null)
            {

                int resultToReturn = vehicleDAO.Insert(vehicle);
                return Ok(resultToReturn);
            }
            else
            {
                return Error();
            }
        }

        [HttpPut]
        [Route("api/vehicle/[action]")]
        public IActionResult Update([FromBody] Vehicle vehicle)
        {
            //manejo de expeciones y mande mensaje a la vista con sentido

            return Ok(vehicleDAO.Update(vehicle));
        }
        public IActionResult Delete(int id)
        {
            //manejo de expeciones y mande mensaje a la vista con sentido

            return Ok(vehicleDAO.Delete(id));
        }
        [HttpGet]
        [Route("api/vehicle/[action]")]
        public IActionResult Get()
        {

            try
            {
                return Ok(vehicleDAO.Get());
            }
            catch (Exception)
            {
                return Error();
            }

        }
        [HttpGet]
        [Route("api/vehicle/[action]")]
        public IActionResult GetByLicensePlate(string licensePlate)
        {
            return Ok(vehicleDAO.Get(licensePlate));
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
