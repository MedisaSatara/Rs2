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
    public class PreventivneMjereService : BaseCRUDService<Model.Models.PreventivneMjere, Database.PreventivneMjere, PreventivneMjereSearchRequest, PreventivneMjereInsertRequest, PreventivneMjereUpdateRequest>, IMjereService
    {
        public PreventivneMjereService(eKartonContext context, IMapper mapper)
        : base(context, mapper)
        {
        }

        public override IQueryable<Database.PreventivneMjere> AddInclude(IQueryable<Database.PreventivneMjere> query, PreventivneMjereSearchRequest? search = null)
        {
            if (search?.isPacijentIncluded == true)
            {
                query = query.Include("Pacijent");
            }
            return base.AddInclude(query, search);
        }
        public override IQueryable<Database.PreventivneMjere> AddFilter(IQueryable<Database.PreventivneMjere> query, PreventivneMjereSearchRequest? search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (search?.isPacijentIncluded == true)
            {
                query = query.Include(x => x.Pacijent);
            }

            return filteredQuery;
        }

    }
}
