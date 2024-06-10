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
    public class OdjelService : BaseService<Model.Models.Odjel, Database.Odjel, OdjelSearchRequest>, IOdjelService
    {
        public OdjelService(eKartonContext context, IMapper mapper)
        : base(context, mapper)
        {
        }


        public override IQueryable<Database.Odjel> AddFilter(IQueryable<Database.Odjel> query, OdjelSearchRequest? search = null)
        {
            if (!string.IsNullOrWhiteSpace(search?.NazivOdjela))
            {
                query = query.Where(x => x.Naziv.StartsWith(search.NazivOdjela));
            }
            if (search?.IsIncludeDoktor == true)
            {
                query = query.Include(x => x.Doktors);
            }


            return base.AddFilter(query, search);
        }

    }
}
