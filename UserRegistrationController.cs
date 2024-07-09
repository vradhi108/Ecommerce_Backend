using Ecommerce.Infrastructure.DatabaseContext;
using Ecommerce.Shared.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyAllowSpecificOrigins")]
    public class UserRegistrationController : ControllerBase
    {
        private readonly UserRegistrationDbcontext _context;
        public UserRegistrationController(UserRegistrationDbcontext context) {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserRegistration>> GetUser()
        {
            return _context.Ecommerce_User_Registration.ToList();
        }

        [HttpGet("{email}/{password}")]

        public bool CheckCustomer(string email, string password)
        {
            var user = _context.Ecommerce_User_Registration.Where(x=>x.email == email).Select(x=>x).ToList();

            if (user == null)
            {
                return false;
            }
            else
            {
                var u = user.Where(x => x.password == password).Select(x => x).ToList();
                if (u.Count > 0)
                {
                    return true;
                }
                else return false;
              
            }
        }

        [HttpPost]
        public ActionResult<UserRegistration> CreateCustomer(UserRegistration user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            _context.Ecommerce_User_Registration.Add(user);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

    }
}
