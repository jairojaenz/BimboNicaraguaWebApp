using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BimboNicaragua.Models;

namespace BimboNicaragua.Controllers
{
    public class EDAController : Controller
    {
        private readonly HttpClient _httpClient;

        public EDAController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            // Consumir las APIs JSON
            var jsonResponse1 = await _httpClient.GetStringAsync("http://edawebapi.centralus.azurecontainer.io:5001/datos");
            var datos = JsonConvert.DeserializeObject<List<DatosEDA>>(jsonResponse1);

            var jsonResponse2 = await _httpClient.GetStringAsync("http://edawebapi.centralus.azurecontainer.io:5001/10datos");
            var datos10 = JsonConvert.DeserializeObject<List<DatosEDA>>(jsonResponse2);

         

            // Pasar los datos a la vista
            var viewModel = new EDAViewModel
            {
                Datos = datos,
                Datos10 = datos10,
             
            };

            return View(viewModel);
        }
    }
}
