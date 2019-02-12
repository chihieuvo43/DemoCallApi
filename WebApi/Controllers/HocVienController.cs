using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
   
    public class HocVienController : BaseController
    {
        private readonly HocVienService _hocVienService;

        public HocVienController(HocVienService hocVienService)
        {
            _hocVienService = hocVienService;
        }
        [HttpGet]
        public ActionResult<List<HocViens>> Get()
        {
            return _hocVienService.Get();
        }
        [HttpGet("{id:length(24)}", Name = "GetHocVien")]
        public ActionResult<HocViens> Get(string id)
        {
            var HocVien= _hocVienService.Get(id);
            if(HocVien==null)
            {
                return NotFound();
            }
            return HocVien;
        }
        [HttpPost]
        public ActionResult<HocViens> Create(HocViens HocVien)
        {
            _hocVienService.Create(HocVien);
            return CreatedAtRoute("GetHocVien", new { id = HocVien.Id.ToString() },HocVien);
        }
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id,HocViens HocVien)
        {
            var hocVien = _hocVienService.Get(id);
            if(hocVien==null)
            {
                return NotFound();
            }
            _hocVienService.Update(id, HocVien);
            return NoContent();
        }
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var hocVien = _hocVienService.Get(id);
            if (hocVien == null)
            {
                return NotFound();
            }
            _hocVienService.Remove(id);
            return NoContent();
        }
    }
}
