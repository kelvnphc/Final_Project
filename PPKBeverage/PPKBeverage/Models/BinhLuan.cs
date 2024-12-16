using System;
using System.Collections.Generic;

#nullable disable

namespace PPKBeverage.Models
{
    public partial class BinhLuan
    {
        public int MaBl { get; set; }
        public string NoiDung { get; set; }
        public DateTime? NgayTao { get; set; }
        public int? MaSp { get; set; }
        public int? KhachHangId { get; set; }
        public int? Sentiment { get; set; }

        public virtual KhachHang KhachHang { get; set; }
        public virtual SanPham MaSpNavigation { get; set; }
    }
}
