using System;
using System.Collections.Generic;

#nullable disable

namespace PPKBeverage.Models
{
    public partial class KhachHang
    {
        public KhachHang()
        {
            BinhLuans = new HashSet<BinhLuan>();
            DonHangs = new HashSet<DonHang>();
        }

        public int MaKh { get; set; }
        public string HoKh { get; set; }
        public string TenKh { get; set; }
        public string UserName { get; set; }
        public string Pass { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }

        public virtual ICollection<BinhLuan> BinhLuans { get; set; }
        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
