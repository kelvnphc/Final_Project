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
using Microsoft.Extensions.Logging;
using PPKBeverage.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace PPKBeverage.Controllers
{

    public class AdminController : Controller
    {
        QUANLYCAPHEContext da = new QUANLYCAPHEContext();
        public readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<AdminController> _logger;
        public AdminController(IHttpContextAccessor httpContextAccessor, ILogger<AdminController> logger)
        {
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;

        }
        public string UploadImage(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                Account account = new Account(
                    "dtq05equd",
                    "352349598637749",
                    "eswxczv-nDvwhpe9VUs5qUizy5E"
                );

                CloudinaryDotNet.Cloudinary cloudinary = new CloudinaryDotNet.Cloudinary(account);
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(fileName, stream)
                    };

                    var uploadResult = cloudinary.Upload(uploadParams);

                    // Lấy URL của ảnh đã tải lên từ kết quả
                    string imageUrl = uploadResult.SecureUri.ToString();

                    // Lưu URL vào cơ sở dữ liệu hoặc thực hiện các thao tác khác
                    // Ví dụ: return URL để sử dụng trong View
                    return imageUrl;
                }
            }
            else
            {
                // Trả về thông báo lỗi nếu không có file được chọn
                return "Error";
            }

        }
        // GET: AdminController
        public ActionResult ListBeverage(string? kw, int? page, string? size, int? gia, int? LoaiId)
        {
            if (!IsAdminLoggedIn())
            {
                return RedirectToAction("DangNhap");
            }
            string check = _httpContextAccessor.HttpContext.Session.GetString("UserName");
            if (check != null)
            {
                TempData["IsLoggedIn"] = true;
                ViewData["SuccessMessage"] = _httpContextAccessor.HttpContext.Session.GetString("SuccessMessage");
                // Lấy tên người dùng từ session
                var nameH = _httpContextAccessor.HttpContext.Session.GetString("HoQl");
                var name = _httpContextAccessor.HttpContext.Session.GetString("TenQl");

                // Khởi tạo truy vấn với các điều kiện lọc ban đầu
                var query = da.SanPhams.Include(c => c.Size).ToList();

                // Lọc theo từ khóa
                if (!string.IsNullOrEmpty(kw))
                {
                    query = query.Where(s => s.Ten.Contains(kw)).ToList();
                }

                // Lọc theo kích thước (size)
                if (!string.IsNullOrEmpty(size))
                {
                    int sizeid;
                    if (int.TryParse(size, out sizeid))
                    {
                        query = query.Where(s => s.SizeId == sizeid).ToList();
                    }
                }

                // Lọc theo giá
                if (gia != null)
                {
                    query = query.Where(s => s.Tien <= (decimal)gia).ToList();
                }
                if (LoaiId != null)
                {
                    query = query.Where(s => s.LoaiId == LoaiId).ToList();
                }
                // Phân trang
                int pageSize = 6;
                int pageNumber = page ?? 1;  // Nếu page là null, mặc định là trang đầu tiên
                int totalItems = query.Count();
                int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
                query = query.OrderBy(item => item.Id)
                       .Skip((pageNumber - 1) * pageSize)
                       .Take(pageSize)
                       .ToList();
                int selectedLoaiId = LoaiId ?? 0;

                // Gửi thông tin phân trang đến View
                ViewData["CurrentPage"] = pageNumber;
                ViewData["TotalPages"] = totalPages;
                ViewData["CurrentLoaiId"] = selectedLoaiId; // Truyền giá trị LoaiId hiện tại vào ViewData

                return View(query);
            }
            else
            {
                return RedirectToAction("DangNhap");
            }
        }

        // GET: AdminController/Details/5
        public ActionResult Details(int id)
        {
            if (!IsAdminLoggedIn())
            {
                return RedirectToAction("DangNhap");
            }
            TempData["IsLoggedIn"] = true;
            var sp = da.SanPhams.Include(c => c.Loai).Include(c => c.Size).FirstOrDefault(s => s.Id == id);
            return View(sp);
        }

        // GET: AdminController/Create
        public ActionResult Create()
        {
            if (!IsAdminLoggedIn())
            {
                return RedirectToAction("DangNhap");
            }
            TempData["IsLoggedIn"] = true;
            ViewData["Sizes"] = new SelectList(da.Sizes, "Id", "Ten");
            ViewData["Loais"] = new SelectList(da.LoaiSanPhams, "LoaiId", "TenLoai");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, IFormFile Anh)
        {
            try
            {
                if (!IsAdminLoggedIn())
                {
                    return RedirectToAction("DangNhap");
                }
                TempData["IsLoggedIn"] = true;
                string imageUrl = "";
                if (Anh != null && Anh.Length > 0)
                {
                    // Gọi hàm UploadImage để upload ảnh lên Cloudinary và nhận lại URL của ảnh
                    imageUrl = UploadImage(Anh);

                    // Gán URL của ảnh cho thuộc tính Anh của model


                }
                // Lấy SizeID và giá từ form

                // Lấy SizeID và giá từ form
                int sizeID = int.Parse(collection["SizeId"]);
                int loaiID = int.Parse(collection["LoaiId"]);
                Console.WriteLine(sizeID);
                SanPham cp = new SanPham();
                cp.MieuTa = collection["MieuTa"];
                cp.Ten = collection["Ten"];
                cp.Anh = imageUrl;
                cp.SizeId = sizeID;
                cp.Tien = Decimal.Parse(collection["Tien"]);
                cp.LoaiId = loaiID;

                da.SanPhams.Add(cp);
                da.SaveChanges();
                return RedirectToAction("ListBeverage");

            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!IsAdminLoggedIn())
            {
                return RedirectToAction("DangNhap");
            }
            TempData["IsLoggedIn"] = true;
            ViewData["Sizes"] = new SelectList(da.Sizes, "Id", "Ten");
            ViewData["Loais"] = new SelectList(da.LoaiSanPhams, "LoaiId", "TenLoai");
            var p = da.SanPhams.Include(c => c.Size).FirstOrDefault(s => s.Id == id);
            return View(p);
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection, IFormFile Anh)
        {

            try
            {
                if (!IsAdminLoggedIn())
                {
                    return RedirectToAction("DangNhap");
                }
                TempData["IsLoggedIn"] = true;
                var cp = da.SanPhams.Include(c => c.Size).FirstOrDefault(s => s.Id == id);
                string anh = cp.Anh;
                int sizeID = int.Parse(collection["SizeId"]);
                int loaiID = int.Parse(collection["LoaiId"]);

                cp.MieuTa = collection["MieuTa"];
                cp.Ten = collection["Ten"];

                cp.SizeId = sizeID;
                cp.Tien = Decimal.Parse(collection["Tien"]);
                cp.LoaiId = loaiID;
                if (Anh != null && Anh.Length > 0)
                {
                    // Tải tệp hình ảnh mới lên Cloudinary và lấy URL của nó
                    string imageUrl = UploadImage(Anh);

                    // Gán URL của hình ảnh mới cho sản phẩm cà phê
                    cp.Anh = imageUrl;
                }
                else
                {
                    // Nếu không có tệp hình ảnh mới được tải lên, giữ nguyên URL của hình ảnh cũ
                    cp.Anh = anh;
                }
                // Gửi các thay đổi đến cơ sở dữ liệu
                da.SaveChanges();

                // Chuyển hướng đến danh sách sản phẩm sau khi cập nhật thành công
                return RedirectToAction("ListBeverage");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            if (!IsAdminLoggedIn())
            {
                return RedirectToAction("DangNhap");
            }
            TempData["IsLoggedIn"] = true;
            var sp = da.SanPhams.Include(c => c.Loai).Include(c => c.Size).FirstOrDefault(s => s.Id == id);
            return View(sp);
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                if (!IsAdminLoggedIn())
                {
                    return RedirectToAction("DangNhap");
                }
                TempData["IsLoggedIn"] = true;
                var p = da.SanPhams.Include(c => c.Size).FirstOrDefault(s => s.Id == id);
                da.SanPhams.Remove(p);
                da.SaveChanges();
                return RedirectToAction("ListBeverage");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ThongKeTheoDoanhThu(DateTime? kw)
        {
            if (!IsAdminLoggedIn())
            {
                return RedirectToAction("DangNhap");
            }
            string check = _httpContextAccessor.HttpContext.Session.GetString("UserName");
            if (check != null)
            {
                TempData["IsLoggedIn"] = true;
                DateTime dateFilter = kw ?? DateTime.Today;

                var result = da.ChiTietDonHangs.
                    Include(ct => ct.SanPham)
                    .ThenInclude(cp => cp.Size)
                    .Where(ct => EF.Functions.DateDiffDay(ct.DonHang.NgayTao, dateFilter) == 0) // Lọc theo ngày tạo đơn hàng
                    .GroupBy(ct => new { SanPhamTen = ct.SanPham.Ten, SizeTen = ct.SanPham.Size.Ten })
                    .Select(g => new
                    {
                        SanPham = g.Key.SanPhamTen + " " + g.Key.SizeTen,
                        DoanhThu = g.Sum(ct => ct.SoLuong * ct.Tien)
                    })
                    .ToList();
                List<ThongKeTheoDoanhThuModel> ds = new List<ThongKeTheoDoanhThuModel>();
                foreach (var item in result)
                {
                    ThongKeTheoDoanhThuModel a = new ThongKeTheoDoanhThuModel();
                    a.Ten = item.SanPham;
                    a.DoanhThu = (decimal)item.DoanhThu;
                    ds.Add(a);
                }
                return View(ds);
            }
            else
                return RedirectToAction("DangNhap");
        }

        public ActionResult ThongKeTheoSoLuongSanPham(DateTime? kw)
        {
            if (!IsAdminLoggedIn())
            {
                return RedirectToAction("DangNhap");
            }
            string check = _httpContextAccessor.HttpContext.Session.GetString("UserName");
            if (check != null)
            {
                TempData["IsLoggedIn"] = true;
                DateTime dateFilter = kw ?? DateTime.Today;
                var result = da.ChiTietDonHangs
                .Include(ct => ct.SanPham)
                .ThenInclude(cp => cp.Size)
                .Where(ct => EF.Functions.DateDiffDay(ct.DonHang.NgayTao, dateFilter) == 0) // Lọc theo ngày tạo đơn hàng
                .GroupBy(ct => new { SanPhamTen = ct.SanPham.Ten, SizeTen = ct.SanPham.Size.Ten })
                .Select(g => new
                {
                    TenSanPham = g.Key.SanPhamTen + " " + g.Key.SizeTen,
                    SoLuongBanDuoc = g.Count() // Sử dụng hàm Count() để đếm số lượng sản phẩm
                }).ToList();
                List<ThongKeSoLuongSanPhamModel> ds = new List<ThongKeSoLuongSanPhamModel>();
                foreach (var item in result)
                {
                    ThongKeSoLuongSanPhamModel a = new ThongKeSoLuongSanPhamModel();
                    a.TenSanPham = item.TenSanPham;
                    a.SoLuong = (int)item.SoLuongBanDuoc;
                    ds.Add(a);
                }
                return View(ds);
            }
            else
                return RedirectToAction("DangNhap");
        }

        private bool IsAdminLoggedIn()
        {
            string username = _httpContextAccessor.HttpContext.Session.GetString("UserName");
            return !string.IsNullOrEmpty(username) && username == "admin";
        }
        public IActionResult Index()
        {
            return View();
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
            var idQL = collection["MaQl"];

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
                QuanLy ql = da.QuanLies.SingleOrDefault(k => k.UserName.Equals(uname.ToString()) && k.Pass.Equals(pass.ToString()));
                if (ql != null)
                {
                    _httpContextAccessor.HttpContext.Session.SetInt32("MaQl", ql.MaQl);
                    _httpContextAccessor.HttpContext.Session.SetString("UserName", ql.UserName);
                    _httpContextAccessor.HttpContext.Session.SetString("HoQl", ql.HoQl); // Lưu họ vào session
                    _httpContextAccessor.HttpContext.Session.SetString("TenQl", ql.TenQl); // Lưu tên vào session
                    TempData["IsLoggedIn"] = true;
                    _httpContextAccessor.HttpContext.Session.SetString("SuccessMessage", "Chúc mừng đăng nhập thành công");
                    _httpContextAccessor.HttpContext.Session.SetString("Username", uname);

                    return RedirectToAction("Index");
                }
                else
                {

                    ModelState.AddModelError(string.Empty, "Thông tin đăng nhập không đúng.");
                    return View();
                }
            }
            return View();
        }

        public ActionResult ListDonHang(int page = 1)
        {
            if (!IsAdminLoggedIn())
            {
                return RedirectToAction("DangNhap");
            }

            string check = _httpContextAccessor.HttpContext.Session.GetString("UserName");
            if (check != null)
            {
                TempData["IsLoggedIn"] = true;
                ViewData["SuccessMessage"] = _httpContextAccessor.HttpContext.Session.GetString("SuccessMessage");

                var nameH = _httpContextAccessor.HttpContext.Session.GetString("HoQl");
                var name = _httpContextAccessor.HttpContext.Session.GetString("TenQl");

                ViewData["FullName"] = !string.IsNullOrEmpty(nameH) && !string.IsNullOrEmpty(name) ? $"{nameH} {name}" : "Quản Lý";

                // Lấy danh sách đơn hàng theo trang
                int pageSize = 4;
                var ds = da.DonHangs.OrderBy(item => item.Id).ToList();
                int totalRecords = ds.Count();
                int totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);

                var pagedDonHangs = ds.Skip((page - 1) * pageSize).Take(pageSize).ToList();

                ViewBag.CurrentPage = page;
                ViewBag.TotalPages = totalPages;

                return View(pagedDonHangs);
            }
            else
            {
                return RedirectToAction("DangNhap");
            }
        }


        public async Task<IActionResult> DonHangDetails(int? id)
        {
            if (!IsAdminLoggedIn())
            {
                return RedirectToAction("DangNhap");
            }
            TempData["IsLoggedIn"] = true;

            if (id == null)
            {
                return NotFound();
            }

            var donHang = await da.DonHangs
                .Include(dh => dh.KhachHang)
                .Include(dh => dh.ChiTietDonHangs)
                    .ThenInclude(ctdh => ctdh.SanPham)
                .Include(dh => dh.ChiTietDonHangs)
                    .ThenInclude(ctdh => ctdh.KhuyenMai)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (donHang == null)
            {
                return NotFound();
            }

            // Kiểm tra nếu KhachHang là null
            if (donHang.KhachHang == null)
            {
                // Xử lý khi KhachHang không có dữ liệu
                // Ví dụ: bạn có thể hiển thị thông báo lỗi hoặc chuyển hướng đến trang khác
                return RedirectToAction("ListDonHang"); // hoặc một hành động khác tùy thuộc vào logic của bạn
            }

            var viewModel = new DonHangDetailsViewModel
            {
                DonHangId = donHang.Id,
                NgayTao = donHang.NgayTao,
                PayPalKey = donHang.PayPalKey,
                KhachHang = donHang.KhachHang,
                ChiTietDonHangs = donHang.ChiTietDonHangs.ToList()
            };

            return View(viewModel);
        }

        // GET: CaPheController/Delete/5
        public ActionResult DeleteDonHang(int id)
        {
            if (!IsAdminLoggedIn())
            {
                return RedirectToAction("DangNhap");
            }
            TempData["IsLoggedIn"] = true;
            var p = da.DonHangs.FirstOrDefault(s => s.Id == id);
            return View(p);
        }


        // POST: CaPheController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteDonHang(int id, IFormCollection collection)
        {
            try
            {
                if (!IsAdminLoggedIn())
                {
                    return RedirectToAction("DangNhap");
                }
                TempData["IsLoggedIn"] = true;

                // Xóa tất cả các ChiTietDonHang liên quan đến DonHang
                var chiTietDonHangs = da.ChiTietDonHangs.Where(ct => ct.DonHangId == id);
                da.ChiTietDonHangs.RemoveRange(chiTietDonHangs);
                da.SaveChanges();

                // Sau đó, xóa DonHang
                var dh = da.DonHangs.FirstOrDefault(s => s.Id == id);
                da.DonHangs.Remove(dh);
                da.SaveChanges();

                return RedirectToAction("ListDonHang");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult ListLoaiSanPham()
        {
            var ds = da.LoaiSanPhams.ToList();
            return View(ds);
        }

        public ActionResult DetailLoaiSanPham(int id)
        {
            var kq = da.LoaiSanPhams.Include(s => s.SanPhams).ThenInclude(s => s.Size)
                .FirstOrDefault(s => s.LoaiId == id);

            return View(kq);
        }

        public ActionResult CreateLoaiSanPham()
        {

            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateLoaiSanPham(LoaiSanPham lsp)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    da.LoaiSanPhams.Add(lsp);
                    da.SaveChanges();
                    return RedirectToAction("ListBeverage");
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "Lỗi khi lưu dữ liệu: " + ex.InnerException?.Message);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Lỗi không xác định: " + ex.Message);
                }
            }

            return View(lsp); // Trả về mô hình để hiển thị lại nếu có lỗi
        }


        // GET: AdminController/Edit/5
        public ActionResult EditLoaiSanPham(int id)
        {

            var p = da.LoaiSanPhams.FirstOrDefault(s => s.LoaiId == id);
            return View(p);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditLoaiSanPham(int id, IFormCollection collection)
        {
            var p = da.LoaiSanPhams.FirstOrDefault(s => s.LoaiId == id);
            p.TenLoai = collection["TenLoai"];
            da.SaveChanges();
            return RedirectToAction("ListBeverage");
        }

        // GET: AdminController/Delete/5
        public ActionResult DeleteLoaiSanPham(int id)
        {
            var sp = da.LoaiSanPhams.FirstOrDefault(s => s.LoaiId == id);
            return View(sp);
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteLoaiSanPham(int id, IFormCollection collection)
        {
            try
            {
                var p = da.LoaiSanPhams.FirstOrDefault(s => s.LoaiId == id);
                da.LoaiSanPhams.Remove(p);
                da.SaveChanges();
                return RedirectToAction("ListBeverage");
            }
            catch
            {
                return View();
            }
        }

    }
}
