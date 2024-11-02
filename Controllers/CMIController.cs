using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BimboNicaragua.Models;

namespace BimboNicaragua.Controllers
{
    public class CMIController : Controller
    {
        private readonly HttpClient _httpClient;

        public CMIController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            // Consumir la API JSON del CMI
            var jsonResponse = await _httpClient.GetStringAsync("http://edawebapi.centralus.azurecontainer.io:5001/cmi");
            var cmiList = JsonConvert.DeserializeObject<List<CMI>>(jsonResponse);

            return View(cmiList);
        }
    }
}
