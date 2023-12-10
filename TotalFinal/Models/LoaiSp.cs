using System;
using System.Collections.Generic;

namespace TotalFinal.Models
{
    public partial class LoaiSp
    {
        public LoaiSp()
        {
            SanPhams = new HashSet<SanPham>();
        }

        public Guid Id { get; set; }
        public string? Ma { get; set; }
        public string? Ten { get; set; }

        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
