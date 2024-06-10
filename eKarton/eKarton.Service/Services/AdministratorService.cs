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
    public class AdministratorService : BaseService<Model.Models.Administrator, Database.Administrator, BaseSearchObject>, IAdministratorService
    {
        public AdministratorService(eKartonContext context, IMapper mapper)
            : base(context, mapper)
        {

        }
    }
}
