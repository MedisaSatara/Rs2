using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKarton.Service.Services
{
    public interface IPacijentService : ICRUDService<Model.Models.Pacijent, Model.Request.PacijentSearchRequest, Model.Request.PacijentInsertRequest, Model.Request.PacijentUpdateRequest>
    {
    }
}
