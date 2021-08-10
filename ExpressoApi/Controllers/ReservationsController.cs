using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpressoApi.Data;
using ExpressoApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ExpressoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class ReservationsController : ControllerBase
    {
        private ExpressoDbContext expressoDbContext;

        public ReservationsController(ExpressoDbContext _expressoDbContext)
        {
            expressoDbContext = _expressoDbContext;
        }

        [HttpPost]
        public IActionResult Post(Reservation reservation)
        {
            expressoDbContext.Reservations.Add(reservation);
            expressoDbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}