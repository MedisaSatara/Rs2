using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKarton.Service.Services
{
    public interface IOsiguranjeService : ICRUDService<Model.Models.Osiguranje, Model.Request.OsiguranjeSearchRequest, Model.Request.OsiguranjeInsertRequest, Model.Request.OsiguranjeUpdateRequest>
    {
    }
}
