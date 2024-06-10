using System;
using System.Collections.Generic;

namespace eKarton.Service.Database
{
    public partial class Osiguranje
    {
        public Osiguranje()
        {
            PacijentOsiguranjes = new HashSet<PacijentOsiguranje>();
        }

        public int OsiguranjeId { get; set; }
        public string Osiguranik { get; set; } = null!;

        public virtual ICollection<PacijentOsiguranje> PacijentOsiguranjes { get; set; }
    }
}
