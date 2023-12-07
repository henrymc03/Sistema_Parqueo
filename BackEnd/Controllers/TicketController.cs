using Microsoft.AspNetCore.Mvc;
using Proyecto1_Lenguajes.Models;
using Proyecto1_Lenguajes.Models.Data;
using Proyecto1_Lenguajes.Models.Domain;
using SmartParkingCR_Backend.Models;
using System.Diagnostics;

namespace Proyecto1_Lenguajes.Controllers
{
    public class TicketController : Controller
    {
        private readonly IConfiguration _configuration;
        TicketDAO ticketDAO;

        public TicketController(  IConfiguration configuration)
        {
            _configuration = configuration;
            ticketDAO = new TicketDAO(_configuration);
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("ticket/[action]")]
        public IActionResult Insert([FromBody] TicketDTO ticket)
        {

            int resultToReturn = ticketDAO.Insert(ticket);
            return Ok(resultToReturn);
        }
        [HttpGet]
        [Route("ticket/[action]")]
        public IActionResult GetByIdUser(int idUser)
        {
            try
            {
                return Ok(ticketDAO.GetByUserId(idUser));
            }
            catch (Exception)
            {
                return Error();
            }
        }


        [HttpGet]
        [Route("ticket/[action]")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(ticketDAO.GetAll());
            }
            catch (Exception)
            {
                return Error();
            }
        }

        [HttpGet]
        [Route("ticket/[action]")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(ticketDAO.GetById(id));
            }
            catch (Exception)
            {
                return Error();
            }
        }
        [HttpPut]
        [Route("ticket/[action]")]
        public IActionResult Update([FromBody] Ticket ticket)
        {
            try
            {
                int resultToReturn = ticketDAO.Update(ticket);
                return Ok(resultToReturn);
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

