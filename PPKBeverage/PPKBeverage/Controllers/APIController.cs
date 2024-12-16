using Microsoft.AspNetCore.Mvc;
using PPKBeverage.Models;
using System;
using static System.Net.Mime.MediaTypeNames;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PPKBeverage.Controllers
{
    [ApiController]
    public class APIController : ControllerBase
    {

        QUANLYCAPHEContext da = new QUANLYCAPHEContext();


        // POST api/<APIController>
        [HttpPost]
        [Route("AddComment")]

        public ActionResult AddComment([FromBody] Test value)
        {
            Console.WriteLine($"NoiDung: {value.NoiDung}, KhachHangId: {value.KhachHangId}");
            BinhLuan binhLuan = new BinhLuan();
            binhLuan.KhachHangId = value.KhachHangId;
            binhLuan.NoiDung = value.NoiDung;
            binhLuan.MaSp = value.SanPhamId;
            binhLuan.Sentiment = value.Sentiment;
            da.BinhLuans.Add(binhLuan);
            da.SaveChanges(); //=)))
            return Ok(new { message = "Comment added successfully!" });

        }


    }
}
