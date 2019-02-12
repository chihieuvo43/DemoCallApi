using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApp.Models;
using WebApplication.Helper;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    //[Route("api/[controller]")]
    public class HocVienController : Controller
    {
        HocVienAPI _api = new HocVienAPI();
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            List<HocViens> HocVien = new List<HocViens>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/HocVien");
            if(res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                HocVien = JsonConvert.DeserializeObject<List<HocViens>>(result);
            }
            return View(HocVien);
        }
    }
}
