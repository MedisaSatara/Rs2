using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKarton.Model.Request
{
    public class KorisnikSearchRequest : BaseSearchObject
    {
        public string? ImeKorisnika { get; set; }
        public string? PrezimeKorisnika { get; set; }
        public bool? IsUlogeIncluded { get; set; }
        public string? UlogaKorisnika { get; set; }
    }
}
