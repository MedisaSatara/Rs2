using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKarton.Service.Services
{
    public interface ITerminService : ICRUDService<Model.Models.Termin, Model.Request.TerminSearchRequest, Model.Request.TerminInsertRequest, Model.Request.TerminUpdateRequest>
    {
    }
}
