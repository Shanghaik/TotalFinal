using System;
using System.Collections.Generic;

namespace TotalFinal.Models
{
    public partial class MoiQuanHe
    {
        public MoiQuanHe()
        {
            Bans = new HashSet<Ban>();
        }

        public Guid Id { get; set; }
        public string? Ma { get; set; }
        public string? Ten { get; set; }

        public virtual ICollection<Ban> Bans { get; set; }
    }
}
