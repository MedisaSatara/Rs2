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
    public class PregledService : BaseService<Model.Models.Pregled, Database.Pregled, PregledSearchRequest>, IPregledService
    {
        public PregledService(eKartonContext context, IMapper mapper)
        : base(context, mapper)
        {
        }


        public override IQueryable<Database.Pregled> AddFilter(IQueryable<Database.Pregled> query, PregledSearchRequest? search = null)
        {
            if (!string.IsNullOrWhiteSpace(search?.imePacijenta))
            {
                query = query.Where(x => x.Pacijent.Ime.StartsWith(search.imePacijenta));
            }
            if (!string.IsNullOrWhiteSpace(search?.prezimePacijenta))
            {
                query = query.Where(x => x.Pacijent.Prezime.StartsWith(search.prezimePacijenta));
            }
            if (!string.IsNullOrWhiteSpace(search?.imeDoktora))
            {
                query = query.Where(x => x.Doktor.Ime.StartsWith(search.imeDoktora));
            }
            if (!string.IsNullOrWhiteSpace(search?.prezimeDoktora))
            {
                query = query.Where(x => x.Doktor.Prezime.StartsWith(search.prezimeDoktora));
            }
            return base.AddFilter(query, search);
        }

    }
}
