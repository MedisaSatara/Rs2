using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKarton.Model.Models
{
    public class PacijentVakcinacija
    {
        public int PacijentVakcinacijaId { get; set; }
        public int? PacijentId { get; set; }
        public int? VakcinacijaId { get; set; }
        public int? Doza { get; set; }
        public string? Datum { get; set; }
        public string? Lokacija { get; set; }

        public virtual Pacijent? Pacijent { get; set; }
      //  public virtual Vakcinacija? Vakcinacija { get; set; }
    }
}
