using PPKBeverage.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PPKBeverage.Models
{
    public class GioHang
    {
        QUANLYCAPHEContext da = new QUANLYCAPHEContext();
        public int Id { get; set; }
        public string Ten { get; set; }
        public string Anh { get; set; }
        public int? SizeId { get; set; }
        public decimal? Tien { get; set; }
        public int SoLuong { get; set; }
        public decimal TongTien { get; private set; }
        public string TenSize { get; set; }

        // Constructor that allows setting quantity
        public GioHang(int id, int quantity)
        {
            Id = id;
            SoLuong = quantity > 0 ? quantity : 1; // Ensure quantity is positive
            LoadProductDetails();
            UpdateTotalPrice();
        }

        // Method to load product details
        private void LoadProductDetails()
        {
            SanPham c = da.SanPhams.Single(s => s.Id == Id);
            Size s = da.Sizes.SingleOrDefault(p => p.Id == c.SizeId);
            Anh = c.Anh;
            Ten = c.Ten;
            Tien = c.Tien;
            TenSize = s?.Ten ?? "Unknown";
        }

        // Method to update quantity and recalculate total price
        public void UpdateQuantity(int quantity)
        {
            if (quantity > 0)
            {
                SoLuong = quantity;
                UpdateTotalPrice();
            }
        }

        // Method to recalculate total price
        private void UpdateTotalPrice()
        {
            TongTien = (Tien ?? 0) * SoLuong;
        }
    }
}
