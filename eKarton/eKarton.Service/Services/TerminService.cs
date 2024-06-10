using AutoMapper;
using eKarton.Model.Request;
using eKarton.Service.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKarton.Service.Services
{
    public class TerminService : BaseCRUDService<Model.Models.Termin, Database.Termin, TerminSearchRequest, TerminInsertRequest, TerminUpdateRequest>, ITerminService
    {
        public TerminService(eKartonContext context, IMapper mapper)
        : base(context, mapper)
        {
        }

    }
}
