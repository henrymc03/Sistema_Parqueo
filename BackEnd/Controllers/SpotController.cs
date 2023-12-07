using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingSystemProject.Models;
using ParkingSystemProject.Models.Data;
using Proyecto1_Lenguajes.Models;
using SmartParkingCR_Backend.Models;
using System.Diagnostics;

namespace Proyecto1_Lenguajes.Controllers
{
    public class SpotController : Controller
    {
      
        private readonly IConfiguration _configuration;
        SpotDAO spotDAO;
        // GET: SpotController
        public SpotController(IConfiguration configuration)
        {
            
            _configuration = configuration;
            //todo: instanciar studentDao solo una vez
            spotDAO = new SpotDAO(_configuration);
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: SpotController/Details/5

        [HttpPost]
        [Route("spot/[action]")]
        public IActionResult Insert([FromBody] Spot spot)
        {
            if (spotDAO.Get(Convert.ToString(spot.Id)).Type == null)
            {

                int resultToReturn = spotDAO.Insert(spot);
                return Ok(resultToReturn);
            }
            else
            {
                return Error();
            }
        }
        // GET: SpotController/Create
        [HttpPut]
        [Route("spot/[action]")]
        public IActionResult Update([FromBody] Spot spot)
        {
            //manejo de expeciones y mande mensaje a la vista con sentido
            try
            {
                return Ok(spotDAO.Update(spot));
            }
            catch (Exception)
            {
                return Error();
            }
        }
        
        [HttpDelete]
        [Route("spot/[action]")]
        public IActionResult Delete(int id)
        {
            //manejo de expeciones y mande mensaje a la vista con sentido

            return Ok(spotDAO.Delete(id));
        }
        [HttpGet]
        [Route("spot/[action]")]
        public IActionResult Get()
        {

            try
            {
                return Ok(spotDAO.Get());
            }
            catch (Exception)
            {
                return Error();
            }

        }
        [HttpGet]
        [Route("spot/[action]")]
        public IActionResult GetById(string idSpot)
        {
            return Ok(spotDAO.Get(idSpot));
        }
        [HttpGet]
        [Route("spot/[action]")]
        public IActionResult GetByParkingLot(int id)
        {
            return Ok(spotDAO.GetByParkingLot(id));
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
