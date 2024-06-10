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
    public class BolnicaService : BaseService<Model.Models.Bolnica, Database.Bolnica, BaseSearchObject>, IBolnicaService
    {
        public BolnicaService(eKartonContext context, IMapper mapper)
        : base(context, mapper)
        {
        }
    }
}
