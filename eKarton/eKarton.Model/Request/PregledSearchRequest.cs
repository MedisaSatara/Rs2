using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKarton.Model.Request
{
    public class PregledSearchRequest : BaseSearchObject
    {
        public string? imeDoktora { get; set; }
        public string? prezimeDoktora { get; set; }
        public string? imePacijenta { get; set; }
        public string? prezimePacijenta { get; set; }
    }
}
