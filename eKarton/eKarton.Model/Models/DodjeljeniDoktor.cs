using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKarton.Model.Models
{
    public class DodjeljeniDoktor
    {
        public int DodjeljeniDoktorId { get; set; }
        public int DoktorId { get; set; }
        public int PacijentId { get; set; }
        public string? DatumOd { get; set; }

        public virtual Doktor Doktor { get; set; } = null!;
        //public virtual Pacijent Pacijent { get; set; } = null!;
    }
}
