using System;
using System.Collections.Generic;

namespace demo2
{
    public partial class Size
    {
        public Size()
        {
            Chitietsanphams = new HashSet<Chitietsanpham>();
        }

        public int Masize { get; set; }
        public string? Tensize { get; set; }
        public string? Mota { get; set; }

        public virtual ICollection<Chitietsanpham> Chitietsanphams { get; set; }
    }
}
