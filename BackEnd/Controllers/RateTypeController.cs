using Microsoft.AspNetCore.Mvc;
using Proyecto1_Lenguajes.Models;
using Proyecto1_Lenguajes.Models.Data;
using Proyecto1_Lenguajes.Models.Domain;
using SmartParkingCR_Backend.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace Proyecto1_Lenguajes.Controllers
{

    public class RateTypeController : Controller
    {
      
        private readonly IConfiguration _configuration;
        RateTypeDAO rateTypeDAO;

        public RateTypeController( IConfiguration configuration)
        {
            
            _configuration = configuration;
            rateTypeDAO = new RateTypeDAO(_configuration);
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("rate/[action]")]
        public IActionResult Insert([FromBody] RateType rateType)
        {

            if (rateTypeDAO.Get(rateType.BookingTime).BookingTime == null)
            {
                int resultToReturn = rateTypeDAO.Insert(rateType);
                return Ok(resultToReturn);
            }
            else
            {
                return Error();
            }
        }

      //  [Authorize]
        [HttpGet]
        [Route("rate/[action]")]
        public IActionResult Get()
        {
            try
            {
                return Ok(rateTypeDAO.Get());
            }
            catch (Exception)
            {
                return Error();
            }
        }

        [HttpGet]
        [Route("rate/[action]")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(rateTypeDAO.GetById(id));
            }
            catch (Exception)
            {
                return Error();
            }
        }

        [HttpGet]
        [Route("rate/[action]")]
        public IActionResult GetByBookingTime(string bookingTime)
        {
            try
            {
                return Ok(rateTypeDAO.Get(bookingTime));
            }
            catch (Exception)
            {
                return Error();
            }
        }
        [HttpPut]
        [Route("rate/[action]")]
        public IActionResult Update([FromBody] RateType rateType)
        {
            try
            {
                return Ok(rateTypeDAO.Update(rateType));
            }
            catch (Exception)
            {
                return Error();
            }
        }
        [HttpDelete]
        [Route("rate/[action]")]
        public IActionResult Delete(string bookingTime)
        {
            try
            {
                return Ok(rateTypeDAO.Delete(bookingTime));
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
