using Ecommerce.Infrastructure.DatabaseContext;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyAllowSpecificOrigins")]
    public class AdminController : ControllerBase
    {
        private readonly UserRegistrationDbcontext _context;
        public AdminController(UserRegistrationDbcontext context) 
        {
            _context = context;
        }

        [HttpGet("{username}/{password}")]
        public bool CheckAdmin(string username, string password)
        {
            var admin = _context.AdminCredentilsTable.Where(x => x.username == username).Select(x => x).ToList();

            if (admin == null)
            {
                return false;
            }
            else
            {
                var u = admin.Where(x => x.password == password).Select(x => x).ToList();
                if (u.Count > 0)
                {
                    return true;
                }
                else return false;

            }
        }

        
    }
}
