using System;
using System.Collections.Generic;

namespace demo2
{
    public partial class Mau
    {
        public Mau()
        {
            Chitietsanphams = new HashSet<Chitietsanpham>();
        }

        public int Mamau { get; set; }
        public string? Tenmau { get; set; }

        public virtual ICollection<Chitietsanpham> Chitietsanphams { get; set; }
    }
}
