using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKarton.Model.Request
{
    public class OdjelSearchRequest : BaseSearchObject
    {
        public string? NazivOdjela { get; set; }
        public string? ImeDoktora { get; set; }
        public string? PrezimeDoktora { get; set; }
        public bool? IsIncludeDoktor { get; set; }
    }
}
