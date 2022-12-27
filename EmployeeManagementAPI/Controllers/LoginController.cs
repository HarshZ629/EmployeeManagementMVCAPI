using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeManagementAPI.Data;

namespace EmployeeManagementAPI.Controllers
{
    public class LoginController : ApiController
    {
        private readonly Context _context = new Context();
        [HttpPost]
        [Route("api/Login/Post")]
        public HttpResponseMessage Post(Admin_details customer)
        
        {
            if (ModelState.IsValid)
            {
                if(customer.AdminEmail == null || customer.AdminName == null || customer.AdminPassword == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                _context.Admin.Add(customer);
                _context.SaveChanges();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, customer);
                //response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = customer.AdminId }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [HttpGet]
        [Route("api/Login/Valid_Admin_Login")]
        public HttpResponseMessage Valid_Admin_Login(string Username,string Password)
        {
            using(Context db = new Context())
            {
                var obj = db.Admin.Where(a => a.AdminEmail.Equals(Username) && a.AdminPassword.Equals(Password)).FirstOrDefault();
                if(obj!=null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    string a = "Username And Password is Invalid";
                    return Request.CreateResponse(HttpStatusCode.BadGateway,a);
                }
            }
        }
    }
}
