using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PPKBeverage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PPKBeverage.Extensions;
using Microsoft.Extensions.Configuration;
using PPKBeverage.PAYPAL;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.SignalR;
using static PPKBeverage.Startup;
namespace PPKBeverage.Controllers
{
    public class GioHangController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<GioHangController> _logger;
        private readonly IPayPalService _payPalService;
        //[HttpPost]
        //public IActionResult UpdateQuantity([FromBody] UpdateQuantityRequest request)
        //{
        //    if (request == null)
        //    {
        //        return Json(new { success = false, message = "Request body is null." });
        //    }

        //    var cart = HttpContext.Session.GetObjectFromJson<List<GioHang>>("GioHang") ?? new List<GioHang>();
        //    var item = cart.FirstOrDefault(p => p.Id == request.ItemId);
        //    if (item != null)
        //    {
        //        item.UpdateQuantity(request.Quantity);

        //        // Update the cart in session
        //        HttpContext.Session.SetObjectAsJson("GioHang", cart);

        //        // Recalculate total price for all items in the cart
        //        var totalCartPrice = cart.Sum(p => p.TongTien);

        //        return Json(new { success = true, totalPrice = totalCartPrice });
        //    }

        //    return Json(new { success = false, message = "Item not found." });
        //}

        public async Task<IActionResult> AddToCartAsync(int id, int quantity = 1)
        {
            List<GioHang> cart = GetListCarts();
            var item = cart.FirstOrDefault(s => s.Id == id);

            if (item != null)
            {
                // Update the existing item’s quantity
                item.UpdateQuantity(item.SoLuong + quantity);
            }
            else
            {
                // Add a new item to the cart
                item = new GioHang(id, quantity);
                cart.Add(item);
            }

            // Save the updated cart to the session
            _httpContextAccessor.HttpContext.Session.SetObjectAsJson("GioHang", cart);

            return RedirectToAction("ListCarts");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateQuantityAsync([FromBody] UpdateQuantityRequest request)
        {
            if (request == null)
            {
                return Json(new { success = false, message = "Request body is null." });
            }

            var cart = HttpContext.Session.GetObjectFromJson<List<GioHang>>("GioHang") ?? new List<GioHang>();
            var item = cart.FirstOrDefault(p => p.Id == request.ItemId);

            if (item != null)
            {
                item.UpdateQuantity(request.Quantity);

                // Update the cart in the session
                HttpContext.Session.SetObjectAsJson("GioHang", cart);

                // Recalculate total price for all items in the cart
                var totalCartPrice = cart.Sum(p => p.TongTien);

                return Json(new { success = true, totalPrice = totalCartPrice });
            }

            return Json(new { success = false, message = "Item not found." });
        }


        public class UpdateQuantityRequest
        {
            public int ItemId { get; set; }
            public int Quantity { get; set; }
        }




        public GioHangController(IConfiguration configuration, IHttpContextAccessor httpContextAccessor, IPayPalService payPalService, ILogger<GioHangController> logger)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
            _payPalService = payPalService;
        }
        QUANLYCAPHEContext da = new QUANLYCAPHEContext();

        public readonly IHttpContextAccessor _httpContextAccessor;

        //public IActionResult AddToCart(int id)
        //{
        //    List<GioHang> gh = GetListCarts();
        //    var c = gh.Find(s => s.Id == id);
        //    if (c != null)
        //    {
        //        c.SoLuong++;
        //    }
        //    else
        //    {
        //        c = new GioHang(id);
        //        gh.Add(c);
        //    }
        //    _httpContextAccessor.HttpContext.Session.SetObjectAsJson("GioHang", gh);
        //    return RedirectToAction("ListCarts");

        //}
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
        // GET: CaPheController/Delete/5
        public ActionResult Delete(int id)
        {
            TempData["IsLoggedIn"] = true;
            var p = da.SanPhams.Include(c => c.Size).FirstOrDefault(s => s.Id == id);
            return View(p);
        }

        // POST: CaPheController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                TempData["IsLoggedIn"] = true;
                var p = da.SanPhams.Include(c => c.Size).FirstOrDefault(s => s.Id == id);
                // Lấy danh sách giỏ hàng từ session
                List<GioHang> gh = GetListCarts();

                // Xóa sản phẩm khỏi giỏ hàng
                var updatedCart = gh.Where(item => item.Id != id).ToList();

                // Cập nhật lại giỏ hàng trong session
                HttpContext.Session.SetObjectAsJson("GioHang", updatedCart);

                // Chuyển hướng người dùng đến trang giỏ hàng
                return RedirectToAction("ListCarts");
            }
            catch
            {
                return View();
            }
        }
        public IActionResult ListCarts()
        {
            var nameH = _httpContextAccessor.HttpContext.Session.GetString("HoKh");
            var name = _httpContextAccessor.HttpContext.Session.GetString("TenKh");
            if (!string.IsNullOrEmpty(nameH) && !string.IsNullOrEmpty(name))
            {
                ViewData["FullName"] = $"{nameH} {name}";
            }
            else
            {
                ViewData["FullName"] = "Khách hàng";
            }
            List<GioHang> gh = GetListCarts();
            ViewBag.CountProduct = gh.Sum(s => s.SoLuong);
            ViewBag.Total = gh.Sum(s => s.TongTien);
            _httpContextAccessor.HttpContext.Session.SetString("TongTien", gh.Sum(s => s.TongTien).ToString());

            return View(gh);
        }

        public ActionResult Order()
        {
            // Tạo mới 1 đơn hàng và lưu trong DonHangs: chỉ thêm ngày đặt hàng(NgayTao)
            DonHang o = new DonHang
            {
                NgayTao = DateTime.Now,
                KhachHangId = _httpContextAccessor.HttpContext.Session.GetInt32("MaKh")
            };

            da.DonHangs.Add(o);
            da.SaveChanges();

            // Lấy danh sách sản phẩm trong giỏ hàng
            List<GioHang> gh = GetListCarts();

            // Duyệt giỏ hàng và thêm vào cơ sở dữ liệu
            foreach (var item in gh)
            {
                ChiTietDonHang odd = new ChiTietDonHang
                {
                    DonHangId = o.Id,
                    SanPhamId = item.Id,
                    SoLuong = item.SoLuong,
                    Tien = item.Tien,
                    KhuyenMaiId = 1 // Nếu có khuyến mãi thì sửa giá trị này
                };

                da.ChiTietDonHangs.Add(odd);
            }
            da.SaveChanges();

            // Lưu giỏ hàng vào session nếu cần
            _httpContextAccessor.HttpContext.Session.SetObjectAsJson("GioHang", gh);

            // Xóa giỏ hàng
            HttpContext.Session.Remove("GioHang");

            // Chuyển hướng đến trang chi tiết đơn hàng
            return RedirectToAction("ChiTietDonHangList", new { orID = o.Id });
        }

        public ActionResult ChiTietDonHangList(int orID)
        {
            var chitietdonghang = da.ChiTietDonHangs
                                        .Include(ct => ct.SanPham) // Nạp thông tin về CaPhe
                                            .ThenInclude(cp => cp.Size) // Nạp thông tin về Size của CaPhe
                                        .Include(ct => ct.KhuyenMai) // Nạp thông tin về KhuyenMai
                                        .Where(s => s.DonHangId == orID)
                                        .ToList();
            var tongTienString = _httpContextAccessor.HttpContext.Session.GetString("TongTien");
            var viewModel = new DonHangViewModel
            {
                DonHangId = orID,
                KhuyenMaiId = chitietdonghang.FirstOrDefault()?.KhuyenMai,
                SanPhams = chitietdonghang.Select(ct => new SanPhamViewModel
                {

                    SanPham = ct.SanPham,
                    SoLuong = ct.SoLuong,
                    Tien = ct.Tien
                }).ToList()
            };
            ViewBag.TongTien = tongTienString;

            return View(viewModel);
        }
        //public IActionResult ThanhToanOnline(int orID)
        //{
        //    var chitietdonghang = da.ChiTietDonHangs
        //                                    .Include(ct => ct.CaPhe) // Nạp thông tin về CaPhe
        //                                        .ThenInclude(cp => cp.Size) // Nạp thông tin về Size của CaPhe
        //                                    .Include(ct => ct.KhuyenMai) // Nạp thông tin về KhuyenMai
        //                                    .Where(s => s.DonHangId == orID)
        //                                    .ToList();
        //    var tongTienString = _httpContextAccessor.HttpContext.Session.GetString("TongTien");
        //    var model = new DonHangViewModel
        //    {
        //        DonHangId = orID,
        //        KhuyenMaiId = chitietdonghang.FirstOrDefault()?.KhuyenMai,
        //        SanPhams = chitietdonghang.Select(ct => new SanPhamViewModel
        //        {

        //            CaPhe = ct.CaPhe,
        //            SoLuong = ct.SoLuong,
        //            Tien = ct.Tien
        //        }).ToList()
        //    };
        //    ViewBag.TongTien = tongTienString;

        //    var vnPayModel = new VnPaymentRequestModel
        //    {
        //        Amout = 100000,
        //        CreatedDate = DateTime.Now,
        //        Description = "Thanh toán online",
        //        FullName = "Luu Van Phuc",
        //        OrderId = orID


        //    };

        //    return Redirect(_vnPayService.CreatePaymentURL(HttpContext, vnPayModel));

        //}

        //public IActionResult PaymentCalLBack()
        //{
        //    var response = _vnPayService.PaymentExecute(Request.Query);
        //    if (response == null || response.VnPayResponseCode != "00")
        //    {
        //        TempData["Message"] = $"Lỗi thanh toán VNPAY { response.VnPayResponseCode} ";
        //    }
        //    //Lưu đơn hàng vào db
        //    TempData["Message"] = "Thanh toán VNPAY thành công";
        //    return RedirectToAction("PaymentSuccess");
        //}
        //public IActionResult PaymentSuccess()
        //{
        //    return View();
        //}
        //public IActionResult PaymentFail()
        //{
        //    return View();
        //}


        //public async Task<IActionResult> ThanhToanPayPal(int orID)
        //{
        //    var tongTienString = _httpContextAccessor.HttpContext.Session.GetString("TongTien");
        //    double tongTien;

        //    if (!double.TryParse(tongTienString, out tongTien))
        //    {
        //        _logger.LogError("Cannot parse TongTien from session");
        //        return RedirectToAction("PaymentFailure");
        //    }

        //    ViewBag.TongTien = tongTienString;
        //    var nameH = _httpContextAccessor.HttpContext.Session.GetString("HoKh");
        //    var name = _httpContextAccessor.HttpContext.Session.GetString("TenKh");
        //    var fullName = $"{nameH} {name}";

        //    PaymentInformationModel model = new PaymentInformationModel
        //    {
        //        OrderType = "Thanh toan tien caphe",
        //        Amount = tongTien,
        //        OrderDescription = "Hoa don thanh toan online",
        //        Name = fullName
        //    };

        //    var url = await _payPalService.CreatePaymentUrl(model);

        //    if (string.IsNullOrEmpty(url))
        //    {
        //        _logger.LogError("Failed to create payment URL");
        //        return RedirectToAction("PaymentFailure");
        //    }

        //    return Redirect(url);
        //}

        public async Task<IActionResult> ThanhToanPayPal(int orID)
        {

            var tongTienString = _httpContextAccessor.HttpContext.Session.GetString("TongTien");
            double tongTien = Double.Parse(tongTienString);

            ViewBag.TongTien = tongTienString;
            var nameH = _httpContextAccessor.HttpContext.Session.GetString("HoKh");
            var name = _httpContextAccessor.HttpContext.Session.GetString("TenKh");
            var fullName = nameH + name;
            PaymentInformationModel model = new PaymentInformationModel
            {
                OrderType = "Thanh toan tien caphe",
                Amount = tongTien,
                OrderDescription = String.Format("Hoa don thanh toan online"),
                Name = fullName
            };
            var url = await _payPalService.CreatePaymentUrl(model);
            return Redirect(url);
        }

        public async Task<IActionResult> PaymentCallback()
        {
            var paymentInfo = _payPalService.PaymentExecute(Request.Query);

            // Trích xuất các giá trị từ kết quả trả về
            string payment_method = paymentInfo.PaymentMethod;
            string success = paymentInfo.Success.ToString();
            string orderId = paymentInfo.OrderId;
            string paymentId = paymentInfo.PaymentId;
            string token = Request.Query["token"];
            string payerId = paymentInfo.PayerId;
            string url = "https://localhost:44396/KhachHang/PaymentCallback";

            _logger.LogInformation("PaymentCallback called with success: {successString}", success);

            if (paymentInfo.Success && !string.IsNullOrEmpty(paymentId) && !string.IsNullOrEmpty(payerId))
            {
                var executedPayment = await _payPalService.ExecutePayment(paymentId, payerId);
                if (executedPayment != null && executedPayment.State == "approved")
                {
                    _logger.LogInformation("Payment was successful.");
                    DonHang o = new DonHang();
                    ViewData["SuccessMessage"] = _httpContextAccessor.HttpContext.Session.GetString("SuccessMessage");
                    var MaKH = _httpContextAccessor.HttpContext.Session.GetInt32("MaKh");
                    o.KhachHangId = MaKH;
                    o.NgayTao = DateTime.Now;
                    o.PayPalKey = url + "&" + "payment_method=" + payment_method + "&" + "success=" + success + "&" + "order_id=" + orderId + "&" + "paymentId=" + paymentId + "&" + "token=" + token + "&" + "PayerID=" + payerId;
                    da.DonHangs.Add(o);
                    da.SaveChanges();
                    int id = o.Id;

                    // Thêm
                    List<GioHang> gh = GetListCarts();
                    // Duyệt giỏ hàng thêm vào db
                    foreach (var item in gh)
                    {
                        // Tạo mới ChiTietDonHang
                        ChiTietDonHang odd = new ChiTietDonHang();
                        // Thiết lập các thuộc tính
                        odd.DonHangId = o.Id;
                        odd.SanPhamId = item.Id;
                        odd.SoLuong = item.SoLuong;
                        odd.Tien = item.Tien;
                        odd.KhuyenMaiId = 1;
                        da.ChiTietDonHangs.Add(odd);
                    }
                    da.SaveChanges();
                    _httpContextAccessor.HttpContext.Session.SetObjectAsJson("GioHang", gh);
                    // Làm rỗng giỏ hàng
                    HttpContext.Session.Remove("GioHang");
                    ViewBag.OrderId = id;
                    ViewBag.TongTien = _httpContextAccessor.HttpContext.Session.GetString("TongTien");
                    return View("PaymentSuccess");
                }
                else
                {
                    _logger.LogWarning("Payment failed or was not approved.");
                    return View("PaymentFailure");
                }
            }
            else
            {
                _logger.LogWarning("Payment failed or success parameter is missing/invalid.");
                return View("PaymentFailure");
            }
        }

        public IActionResult PaymentSuccess()
        {
            return View();
        }
        //public async Task<IActionResult> ChiTietGiaoHang(int donHangId)
        //{
        //    //var giaoHang = await da.GiaoHangs
        //    //    .Include(g => g.TaiXe)
        //    //   // .Include(g => g.TaiXe)
        //    //    .Include(g => g.LichTrinhGiaoHangs)
        //    //    .FirstOrDefaultAsync(g => g.GiaoHangId == donHangId);

        //    if (giaoHang == null)
        //    {
        //        return NotFound();
        //    }

        //    var giaoHangViewModel = new GiaoHangViewModel
        //    {
        //        GiaoHangId = giaoHang.GiaoHangId,
        //        TenTaiXe = giaoHang.TaiXe.HoTen,
        //        SoDienThoaiTaiXe = giaoHang.TaiXe.SoDienThoai,
        //        BienSoXe = giaoHang.BienSoXe,
        //        HinhDaiDien = giaoHang.TaiXe.ViTriHienTai,
        //        ThoiGianGiaoHangDuKien = giaoHang.ThoiGianGiaoHang, // Đã là kiểu DateTime? rồi
        //        TrangThai = giaoHang.TrangThai,
        //        //LichTrinh = giaoHang.LichTrinhGiaoHangs.Select(l => new LichTrinhViewModel
        //        //{
        //        //    ViDo = l.ViDo,
        //        //    KinhDo = l.KinhDo,
        //        //    ThoiGian = l.ThoiGian // Đã là kiểu DateTime rồi
        //        //}).ToList()
        //    };

        //    return View(giaoHangViewModel);
        //}
        //public async Task<IActionResult> CapNhatViTriTaiXe(int taiXeId, string viDo, string kinhDo)
        //{
        //    var taiXe = await da.TaiXes.FindAsync(taiXeId);
        //    if (taiXe == null)
        //    {
        //        return NotFound();
        //    }

        //    taiXe.ViDo = viDo;
        //    taiXe.KinhDo = kinhDo;

        //    da.TaiXes.Update(taiXe);
        //    await da.SaveChangesAsync();

        //    // Thông báo cho các client về cập nhật vị trí
        //    await _hubContext.Clients.All.SendAsync("CapNhatViTri", new
        //    {
        //        TaiXeId = taiXeId,
        //        ViDo = viDo,
        //        KinhDo = kinhDo
        //    });

        //    return Ok();
        //}



        public IActionResult PaymentFailure()
        {
            return View();
        }
    }
}

