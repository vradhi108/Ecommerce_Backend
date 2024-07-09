using Ecommerce.Infrastructure.DatabaseContext;
using Ecommerce.Shared.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyAllowSpecificOrigins")]
    public class SellerRegistrationController : ControllerBase
    {
        private readonly UserRegistrationDbcontext _context;
        public SellerRegistrationController(UserRegistrationDbcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SellerRegistration>> GetSeller()
        {
            return _context.SellerRegistrationsVB.ToList();
        }

        [HttpGet("{userid}/{sellerpassword}")]

        public bool CheckSeller(string userid, string sellerpassword)
        {
            var user = _context.SellerRegistrationsVB.Where(x => x.userid == userid).Select(x => x).ToList();

            if (user == null)
            {
                return false;
            }
            else
            {
                var u = user.Where(x => x.sellerpassword == sellerpassword).Select(x => x).ToList();
                if (u.Count > 0)
                {
                    return true;
                }
                else return false;

            }
        }

        //[HttpGet]

        //public bool CheckSellerPresent(string emailid)
        //{
        //    var user = _context.SellerRegistrationsVB.Where(x => x.emailid == emailid).Select(x => x).ToList();

        //    if (user.Count > 0)
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        [HttpPost]
        public ActionResult<SellerRegistration> CreateCustomer(SellerRegistration seller)
        {
            if (seller == null)
            {
                return BadRequest();
            }
            var user = _context.SellerRegistrationsVB.Where(x => x.emailid == seller.emailid).Select(x => x).ToList();
            if (user.Count > 0) {
                
                return BadRequest();
            }
            _context.SellerRegistrationsVB.Add(seller);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetSeller), new { id = seller.SellerId }, seller);
        }

        [HttpGet("changesellerstatus/{userid}")]

        public void UpdateSellerStatus(string userid)
        {
            var seller = _context.SellerRegistrationsVB.Where(x => x.userid == userid).Select(x => x).ToList();


            foreach(var item in seller)
            {
               

                if (item.status == 1) item.status = 0;
                else item.status = 1;
                _context.Entry(item).State = EntityState.Modified;

            }
            _context.SaveChangesAsync();
           
        }
        public static implicit operator SellerRegistrationController(UserRegistrationDbcontext v)
        {
            throw new NotImplementedException();
        }
    }
}
