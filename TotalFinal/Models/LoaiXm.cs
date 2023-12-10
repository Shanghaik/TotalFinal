using System;
using System.Collections.Generic;

namespace TotalFinal.Models
{
    public partial class LoaiXm
    {
        public LoaiXm()
        {
            XeMays = new HashSet<XeMay>();
        }

        public Guid Id { get; set; }
        public string? Ma { get; set; }
        public string? Ten { get; set; }

        public virtual ICollection<XeMay> XeMays { get; set; }
    }
}
