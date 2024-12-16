using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PPKBeverage.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using PPKBeverage.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Authentication.Twitter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Localization;
namespace PPKBeverage.Controllers
{
    public class KhachHangController : Controller
    {
        QUANLYCAPHEContext da = new QUANLYCAPHEContext();
        private readonly IConfiguration _configuration;
        public readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<KhachHangController> _logger;
        private string HoKh, TenKh, UserName, Pass, DiaChi, SoDienThoai;
        private readonly IStringLocalizer<HomeController> _localizer;
        public KhachHangController(IConfiguration configuration, IHttpContextAccessor httpContextAccessor, ILogger<KhachHangController> logger, IStringLocalizer<HomeController> localizer)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
            _localizer = localizer;

        }
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }

        // GET: NguoiDungController
        public ActionResult ListBeverage(string? kw, int? page, string? size, int? gia, int? LoaiId)
        {
            // Lấy tên người dùng từ session
            var nameH = _httpContextAccessor.HttpContext.Session.GetString("HoKh");
            var name = _httpContextAccessor.HttpContext.Session.GetString("TenKh");

            // Lấy giỏ hàng từ session
            List<GioHang> cart = HttpContext.Session.GetObjectFromJson<List<GioHang>>("GioHang") ?? new List<GioHang>();

            // Kiểm tra và đảm bảo dữ liệu session được tải đúng
            ViewBag.Cart = cart;

            if (!string.IsNullOrEmpty(nameH) && !string.IsNullOrEmpty(name))
            {
                ViewData["FullName"] = $"{nameH} {name}";
            }
            else
            {
                ViewData["FullName"] = "Khách hàng";
            }

            // Xóa thông báo từ session
            _httpContextAccessor.HttpContext.Session.Remove("SuccessMessage");
            var message = _localizer["hi"];
            var ds = da.SanPhams.Include(c => c.Size).ToList();

            // Áp dụng bộ lọc nếu có
            if (!string.IsNullOrEmpty(kw))
            {
                ds = ds.Where(s => s.Ten.IndexOf(kw, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }
            if (!string.IsNullOrEmpty(size))
            {
                int sizeid = int.Parse(size);
                ds = ds.Where(s => s.SizeId == sizeid).ToList();
            }
            if (gia != null)
            {
                ds = ds.Where(s => s.Tien <= (decimal)gia).ToList();
            }
            if (LoaiId != null)
            {
                ds = ds.Where(s => s.LoaiId == LoaiId).ToList();
            }

            // Phân trang
            int pageSize = 6;
            int pageNumber = page ?? 1;  // Nếu page là null, mặc định là trang đầu tiên
            int totalItems = ds.Count();
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            ds = ds.OrderBy(item => item.Id)
                   .Skip((pageNumber - 1) * pageSize)
                   .Take(pageSize)
                   .ToList();
            int selectedLoaiId = LoaiId ?? 0;
            // Gửi thông tin phân trang đến View
            ViewData["CurrentPage"] = pageNumber;
            ViewData["TotalPages"] = totalPages;
            ViewData["CurrentLoaiId"] = selectedLoaiId; // Truyền giá trị LoaiId hiện tại vào ViewData

            return View(ds);
        }




        // GET: NguoiDungController/Details/5
        public ActionResult Details(int id)
        {

            //var p = da.SanPhams.Include(c => c.Size).FirstOrDefault(s => s.Id == id);
            //var ds = da.BinhLuans.Where(s => s.MaSp == id).ToList();
            //return View(p);
            var maKh = _httpContextAccessor.HttpContext.Session.GetInt32("MaKh");
            var khachHang = da.KhachHangs.FirstOrDefault(kh => kh.MaKh == maKh);
            if (khachHang != null)
            {
                ViewBag.TenKhachHang = $"{khachHang.HoKh} {khachHang.TenKh}";
            }
            ViewBag.SanPhamId = id;
            Console.WriteLine(maKh);
            // Truyền maKh vào view thông qua ViewBag
            ViewBag.MaKh = maKh;
            var product = da.SanPhams.Include(c => c.Size).Include(c => c.BinhLuans).ThenInclude(b => b.KhachHang).FirstOrDefault(s => s.Id == id); 
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        public ActionResult DangKy()
        {
            //KhachHang kh = new KhachHang();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DangKyAsync(IFormCollection collection)
        {
            KhachHang kh = new KhachHang();
            // Gán các giá tị người dùng nhập liệu cho các biến
            HoKh = collection["HoKh"];
            TenKh = collection["TenKh"];
            UserName = collection["UserName"];
            Pass = collection["Pass"];
            DiaChi = collection["DiaChi"];
            SoDienThoai = collection["SoDienThoai"];
            _httpContextAccessor.HttpContext.Session.SetString("Pass", Pass);
            _httpContextAccessor.HttpContext.Session.SetString("DiaChi", DiaChi);
            _httpContextAccessor.HttpContext.Session.SetString("HoKh", HoKh);
            _httpContextAccessor.HttpContext.Session.SetString("TenKh", TenKh);
            _httpContextAccessor.HttpContext.Session.SetString("UserName", UserName);
            _httpContextAccessor.HttpContext.Session.SetString("SoDienThoai", SoDienThoai);

            if (System.String.IsNullOrEmpty(HoKh))
            {
                ViewData["Loil"] = "Họ khách hàng không được để trống";
            }
            else if (System.String.IsNullOrEmpty(TenKh))
            {
                ViewData["Loi2"] = "Tên khách hàng không được để trống";
            }
            else if (System.String.IsNullOrEmpty(UserName))
            {
                ViewData["Loi3"] = "Phải nhập tên đăng nhập";
            }
            else if (System.String.IsNullOrEmpty(Pass))
            {
                ViewData["Loi4"] = "Phải nhập mật khẩu";
            }
            else if (System.String.IsNullOrEmpty(DiaChi))
            {
                ViewData["Loi5"] = "Phải nhập địa chỉ";
            }
            else if (System.String.IsNullOrEmpty(SoDienThoai))
            {
                ViewData["Loi6"] = "Phải nhập số điện thoại";
            }
            else
            {
                ////Gán giá trị cho đối tượng được tạo mới (kh)
                kh.HoKh = HoKh;
                kh.TenKh = TenKh;
                kh.UserName = UserName;
                kh.Pass = Pass;
                kh.DiaChi = DiaChi;
                kh.SoDienThoai = SoDienThoai;
                da.KhachHangs.Add(kh);
                da.SaveChanges();
                //string internationalPhoneNumber = "+84" + SoDienThoai.Substring(1);
                //Console.WriteLine(internationalPhoneNumber);
                //var otpService = new OtpService(_configuration, _httpContextAccessor);
                //otpService.SendOtp(internationalPhoneNumber); // Truyền số điện thoại cần gửi mã OTP vào hàm SendOtp

                //_httpContextAccessor.HttpContext.Session.SetString("UserPhoneNumber", SoDienThoai);
            }
            return RedirectToAction("DangNhap");
        }

        public ActionResult VerifyOtp()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VerifyOtp(string otp)
        {
            var sessionOtp = _httpContextAccessor.HttpContext.Session.GetString("OTP");
            var userPhoneNumber = _httpContextAccessor.HttpContext.Session.GetString("UserPhoneNumber");
            Console.WriteLine("OTP khach hang nhap vao la" + otp);
            Console.WriteLine("OTP tao ra la : " + sessionOtp);
            if (sessionOtp == otp)
            {
                HoKh = _httpContextAccessor.HttpContext.Session.GetString("HoKh");
                TenKh = _httpContextAccessor.HttpContext.Session.GetString("TenKh");
                UserName = _httpContextAccessor.HttpContext.Session.GetString("UserName");
                Pass = _httpContextAccessor.HttpContext.Session.GetString("Pass");
                DiaChi = _httpContextAccessor.HttpContext.Session.GetString("DiaChi");
                SoDienThoai = _httpContextAccessor.HttpContext.Session.GetString("SoDienThoai");
                Console.WriteLine("OTP khach hang nhap vao la" + otp);
                Console.WriteLine("OTP tao ra la : " + sessionOtp);
                KhachHang kh = new KhachHang();
                kh.HoKh = HoKh;
                kh.TenKh = TenKh;
                kh.UserName = UserName;
                kh.Pass = Pass;
                kh.DiaChi = DiaChi;
                kh.SoDienThoai = SoDienThoai;
                da.KhachHangs.Add(kh);
                da.SaveChanges();
                _httpContextAccessor.HttpContext.Session.Remove("OTP");
                _httpContextAccessor.HttpContext.Session.Remove("UserPhoneNumber");

                // OTP verification success, proceed with further actions (e.g., login user)
                return RedirectToAction("DangNhap");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid OTP. Please try again.");
                return View();
            }
        }

        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangNhap(IFormCollection collection)
        {
            var uname = collection["UserName"];
            var pass = collection["Pass"];
            var idKH = collection["MaKh"];

            if (System.String.IsNullOrEmpty(uname))
            {
                ViewData["Loi1"] = "Phải nhập tên đăng nhập";
            }
            else if (System.String.IsNullOrEmpty(pass))
            {
                ViewData["Loi2"] = "Phải nhập mật khẩu";
            }
            else
            {
                KhachHang kh = da.KhachHangs.SingleOrDefault(k => k.UserName.Equals(uname.ToString()) && k.Pass.Equals(pass.ToString()));
                if (kh != null)
                {
                    _httpContextAccessor.HttpContext.Session.SetInt32("MaKh", kh.MaKh);
                    _httpContextAccessor.HttpContext.Session.SetString("UserName", kh.UserName);
                    _httpContextAccessor.HttpContext.Session.SetString("HoKh", kh.HoKh); // Lưu họ vào session
                    _httpContextAccessor.HttpContext.Session.SetString("TenKh", kh.TenKh); // Lưu tên vào session
                    _httpContextAccessor.HttpContext.Session.SetString("SuccessMessage", "Chúc mừng đăng nhập thành công");
                    return RedirectToAction("ListBeverage");
                }
                else 
                {

                    ModelState.AddModelError(string.Empty, "Thông tin đăng nhập không đúng.");
                    return View();
                }
            }
            return View();
        }
        public IActionResult GoogleLogin()
        {
            var redirectUrl = Url.Action("GoogleResponse", "KhachHang", null, Request.Scheme);
            var properties = new AuthenticationProperties
            {
                RedirectUri = redirectUrl
            };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            if (result.Succeeded)
            {
                // Lưu thông tin người dùng vào session
                var userName = result.Principal.FindFirstValue(ClaimTypes.Name);
                HttpContext.Session.SetString("UserName", userName);
                // Chuyển hướng đến trang danh sách đồ uống
                return RedirectToAction("ListBeverage", "KhachHang");
            }
            return RedirectToAction("DangNhap", "KhachHang"); // Chuyển hướng đến trang đăng nhập nếu thất bại
        }
        public IActionResult FacebookLogin()
        {
            var redirectUrl = Url.Action("FacebookResponse", "KhachHang", null, Request.Scheme);
            var properties = new AuthenticationProperties
            {
                RedirectUri = redirectUrl
            };
            return Challenge(properties, FacebookDefaults.AuthenticationScheme);
        }
        public async Task<IActionResult> FacebookResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            if (result.Succeeded)
            {
                // Lưu thông tin người dùng vào session
                var userName = result.Principal.FindFirstValue(ClaimTypes.Name);
                HttpContext.Session.SetString("UserName", userName);

                // Chuyển hướng đến trang danh sách đồ uống
                return RedirectToAction("ListBeverage", "KhachHang");
            }
            return RedirectToAction("DangNhap", "KhachHang"); // Chuyển hướng đến trang đăng nhập nếu thất bại
        }
        public IActionResult TwitterLogin()
        {
            var redirectUrl = Url.Action("TwitterResponse", "KhachHang", null, Request.Scheme);
            var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
            return Challenge(properties, TwitterDefaults.AuthenticationScheme);
        }

        public async Task<IActionResult> TwitterResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            if (result.Succeeded)
            {
                // Lưu thông tin người dùng vào session
                var userName = result.Principal.Identity.Name;
                HttpContext.Session.SetString("UserName", userName);

                // Chuyển hướng đến trang bạn muốn sau khi đăng nhập thành công
                return RedirectToAction("ListBeverage", "KhachHang");
            }

            // Chuyển hướng đến trang đăng nhập nếu thất bại
            return RedirectToAction("DangNhap", "KhachHang");
        }
        public ActionResult DangXuat()
        {
            // Xóa các giá trị khỏi session
            _httpContextAccessor.HttpContext.Session.Remove("MaKh");
            _httpContextAccessor.HttpContext.Session.Remove("UserName");
            _httpContextAccessor.HttpContext.Session.Remove("HoKh");
            _httpContextAccessor.HttpContext.Session.Remove("TenKh");

            // Thông báo đăng xuất thành công (tuỳ chọn)
            TempData["Message"] = "Đăng xuất thành công.";

            // Chuyển hướng về trang đăng nhập hoặc trang chính
            return RedirectToAction("DangNhap", "KhachHang");
        }

        public List<GioHang> GetListCarts()
        {
            List<GioHang> carts = _httpContextAccessor.HttpContext.Session.GetObjectFromJson<List<GioHang>>("GioHang");

            //Chưa có thì tạo mới giỏ hàng trống
            if (carts == null)
            {
                carts = new List<GioHang>();
            }
            //Có rồi thì lấy các sp trả về
            return carts;
        }


      
    }
}
