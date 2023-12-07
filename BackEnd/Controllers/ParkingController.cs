using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proyecto1_Lenguajes.Models.Data;
using SmartParkingCR_Backend.Models;

namespace SmartParkingCR_Backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ParkingController : Controller
    {
        private readonly IConfiguration _configuration;
        ParkingDAO parkingDAO;

        public ParkingController(IConfiguration configuration)
        {

            _configuration = configuration;
            parkingDAO = new ParkingDAO(_configuration);
        }


        [HttpGet]
        public List<ParkingLot> GetNc()
        {
            return parkingDAO.Get();
        }

        /// <summary>
        /// Inserta el parqueo
        /// </summary>
        /// <remark>
        /// </remark>
        /// <param name="parking">Id del registro</param>]
        /// <returns> </returns>
        /// <response code="200">OK. Devuelve la lista de los registros</response>
        /// <response code="404">NotFound. No se encontro el registro</response>
        [HttpPost]
        [Route("[action]")]
        public IActionResult Insert(ParkingLot parking)
        {
           
            if (parkingDAO.Get(parking.Name).Name == null)
            {

                int resultToReturn = parkingDAO.Insert(parking);
                return Ok(resultToReturn);
            }
            else
            {
                return null;
            }
                }

        
        [HttpPut]
        public IActionResult Update(ParkingLot parking)
        {
            //manejo de expeciones y mande mensaje a la vista con sentido

            return Ok(parkingDAO.Update(parking));
        }
        [HttpDelete]
        [Route("[action]")]
        public IActionResult DeleteParking(int id)
        {
            //manejo de expeciones y mande mensaje a la vista con sentido

            return Ok(parkingDAO.Delete(id));
        }


      
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetName(int id)
        {
            ParkingLot parking = parkingDAO.GetNameParking(id);
            return Ok(parking);
        }
 
        [HttpGet]
        [Route("[action]/{{name}}")]
        public IActionResult GetByNameUpdateParking(string name)
        {
            return Ok(parkingDAO.Get(name));
        }
        
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetCartago()
        {
            return Ok(parkingDAO.GetCartago());

        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetSanJose()
        {

           // ParkingDAO parking = new ParkingDAO();
            return Ok(parkingDAO.GetSanJose());

        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetHeredia()
        {
            return Ok(parkingDAO.GetHeredia());
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAlajuela()
        {
            return Ok(parkingDAO.GetAlajuela());
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetPuntarenas()
        {
          //  ParkingDAO parking = new ParkingDAO();
            return Ok(parkingDAO.GetPuntarenas());

        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetLimon()
        {
            ParkingDAO parking = new ParkingDAO();
            return Ok(parking.GetLimon());

        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetGuanacaste()
        {
           // ParkingDAO parking = new ParkingDAO();
            return Ok(parkingDAO.GetGuanacaste());

        }



    }
}
