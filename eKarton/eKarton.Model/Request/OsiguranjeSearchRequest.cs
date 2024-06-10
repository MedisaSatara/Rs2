using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKarton.Model.Request
{
    public class OsiguranjeSearchRequest : BaseSearchObject
    {
        public string? Osiguranik { get; set; }
        public string? ImePacijenta { get; set; }
        public string? PrezimePacijenta { get; set; }
        public bool? isPacijentInclude { get; set; }

    }
}
