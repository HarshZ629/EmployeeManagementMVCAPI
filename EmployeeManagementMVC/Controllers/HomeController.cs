using EmployeeManagementMVC.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using Newtonsoft.Json;

namespace EmployeeManagementMVC.Controllers
{
    public class HomeController : Controller
    {
        private static string WebApiUrl = "http://localhost:53338/";
        // GET: Home

        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AdminLogin(Admin_Login u)
        {
            var tokenBased = string.Empty;
            if(ModelState.IsValid)
            {
                using(var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Clear();
                    client.BaseAddress = new Uri(WebApiUrl);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var responseMessage = await client.GetAsync("api/Login/Valid_Admin_Login?Username=" + u.AdminEmail + "&Password=" + u.AdminPassword + "");
                    if(responseMessage.IsSuccessStatusCode)
                    {
                        var resultMessage = responseMessage.Content.ReadAsStringAsync().Result;
                        tokenBased = JsonConvert.DeserializeObject<String>(resultMessage);
                        return RedirectToAction("");
                    }
                    else
                    {
                        return RedirectToAction("Error");

                    }

                }
            }
            return null;
        }
        public ActionResult RegistrationAdmin()
        {
            return View();
        }
    }
}