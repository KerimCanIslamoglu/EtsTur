using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Etstur.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Etstur.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new ResponseListModel<UserModel>();
            var client = new HttpClient();
            try
            {
                string baseAddress ="https://localhost:44337/api/User/GetUsers";

                using (HttpResponseMessage httpResponse = client.GetAsync(baseAddress).Result)
                {
                    httpResponse.EnsureSuccessStatusCode();
                    model = JsonConvert.DeserializeObject<ResponseListModel<UserModel>>(httpResponse.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception ex)
            {
                model = new ResponseListModel<UserModel>
                {
                    Success = false,
                    Message = ex.ToString(),
                    Response = null
                };
            }

            return View(model);
        }

        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(UserModel userModel)
        {
            var model = new ResponseListModel<UserModel>();
            var client = new HttpClient();
            try
            {
                var json = JsonConvert.SerializeObject(userModel);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                string baseAddress = "https://localhost:44337/api/User/CreateUser";

                using (HttpResponseMessage httpResponse = client.PostAsync(baseAddress, data).Result)
                {
                    httpResponse.EnsureSuccessStatusCode();
                    model = JsonConvert.DeserializeObject<ResponseListModel<UserModel>>(httpResponse.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception ex)
            {
                model = new ResponseListModel<UserModel>
                {
                    Success = false,
                    Message = ex.ToString(),
                    Response = null
                };
            }


            return RedirectToAction("Index", model);
        }
    }
}
