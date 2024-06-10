using eKarton.Model.Models;
using eKarton.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eKarton.Controllers
{
    [Route("[controller]")]
    public class DoktorController : BaseController<Model.Models.Doktor, Model.Request.OdjelSearchRequest>
    {
        public DoktorController(ILogger<BaseController<Doktor, Model.Request.OdjelSearchRequest>> logger, IDoktorService service) : base(logger, service)
        {
        }
    }
}
