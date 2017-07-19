using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace BizzDesk_Leap_API.Security
{
    public class RegisterController : ApiController
    {
        ApplicationUserDBContext _db;
        public RegisterController()
        {
            _db = new ApplicationUserDBContext();
        }

        private ApplicationUserManager UserManager
        {
            get
            {
                return Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        public IQueryable<ApplicationUser> Get()
        {
            return _db.Users;
        }

        public IHttpActionResult Post(Register model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = new ApplicationUser 
            { 
                Email = model.Email,
                UserName = model.Email,
                EmailConfirmed = true,
                RoleID = model.RoleID
            };

            var result = UserManager.Create(user, model.Password);
            return result.Succeeded ? Ok() : GetErrorResult(result);
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (result.Errors != null)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
            }

            if (ModelState.IsValid)
            {
                return BadRequest();
            }

            return BadRequest(ModelState);
        }

    }
}
