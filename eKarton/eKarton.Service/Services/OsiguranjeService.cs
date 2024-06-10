using AutoMapper;
using eKarton.Model.Request;
using eKarton.Service.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKarton.Service.Services
{
    public class OsiguranjeService : BaseCRUDService<Model.Models.Osiguranje, Database.Osiguranje, OsiguranjeSearchRequest, OsiguranjeInsertRequest, OsiguranjeUpdateRequest>, IOsiguranjeService
    {
        public OsiguranjeService(eKartonContext context, IMapper mapper)
        : base(context, mapper)
        {
        }

        public override IQueryable<Database.Osiguranje> AddInclude(IQueryable<Database.Osiguranje> query, OsiguranjeSearchRequest? search = null)
        {
            if (search?.isPacijentInclude == true)
            {
                query = query.Include("PacijentOsiguranjes.Pacijent");
            }
            return base.AddInclude(query, search);
        }
        public override IQueryable<Database.Osiguranje> AddFilter(IQueryable<Database.Osiguranje> query, OsiguranjeSearchRequest? search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (!string.IsNullOrWhiteSpace(search?.Osiguranik))
            {
                filteredQuery = filteredQuery.Where(x => x.Osiguranik == search.Osiguranik);
            }

            return filteredQuery;
        }

    }
}
