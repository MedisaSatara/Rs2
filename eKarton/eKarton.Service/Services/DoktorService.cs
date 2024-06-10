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
    public class DoktorService : BaseService<Model.Models.Doktor, Database.Doktor, OdjelSearchRequest>, IDoktorService
    {
        public DoktorService(eKartonContext context, IMapper mapper)
            : base(context, mapper)
        {

        }


        public override IQueryable<Database.Doktor> AddFilter(IQueryable<Database.Doktor> query, OdjelSearchRequest? search = null)
        {
            if (!string.IsNullOrWhiteSpace(search?.ImeDoktora))
            {
                query = query.Where(x => x.Ime.StartsWith(search.ImeDoktora));
            }
            if (!string.IsNullOrWhiteSpace(search?.PrezimeDoktora))
            {
                query = query.Where(x => x.Prezime.StartsWith(search.PrezimeDoktora));
            }
            if (!string.IsNullOrWhiteSpace(search?.NazivOdjela))
            {
                query = query.Where(x => x.Odjel.Naziv == search.NazivOdjela);
            }

            return base.AddFilter(query, search);
        }


    }
}
