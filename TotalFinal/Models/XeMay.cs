using System;
using System.Collections.Generic;

namespace TotalFinal.Models
{
    public partial class XeMay
    {
        public Guid Id { get; set; }
        public string? Ma { get; set; }
        public string? Ten { get; set; }
        public DateTime? NgaySx { get; set; }
        public string? Mota { get; set; }
        public decimal? GiaNhap { get; set; }
        public decimal? GiaBan { get; set; }
        public int? SoLuong { get; set; }
        public string? Website { get; set; }
        public Guid? IdLxm { get; set; }
        public int? TrangThai { get; set; }

        public virtual LoaiXm? IdLxmNavigation { get; set; }
    }
}
