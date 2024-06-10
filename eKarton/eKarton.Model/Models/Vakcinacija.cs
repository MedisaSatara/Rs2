using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKarton.Model.Models
{
    public class Vakcinacija
    {
        public int VakcinacijaId { get; set; }
        public string NazivVakcine { get; set; } = null!;

        public virtual ICollection<PacijentVakcinacija> PacijentVakcinacijas { get; set; }
    }
}
