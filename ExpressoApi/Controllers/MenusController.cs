using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpressoApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace ExpressoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
   
    public class MenusController : ControllerBase
    {
        ExpressoDbContext expressoDbContext;

        public MenusController(ExpressoDbContext _expressoDbContext)
        {
            expressoDbContext = _expressoDbContext;
        }

        [HttpGet]
      
        public IActionResult GetMenus()
        {
            var menus = expressoDbContext.Menus.Include("SubMenus");
            return Ok(menus);
        }

        [HttpGet("{id}")]
        
        public IActionResult GetMenu(int id)
        {
            var menu = expressoDbContext.Menus.Include("SubMenus").FirstOrDefault(m => m.Id == id);
            if (menu == null)
            {
                return NotFound();
            }

            return Ok(menu);
        }
    }
}