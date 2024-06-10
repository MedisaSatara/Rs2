using eKarton.Model.Models;
using eKarton.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eKarton.Controllers
{
    [Route("[controller]")]
    public class OdjelController : BaseController<Model.Models.Odjel, Model.Request.OdjelSearchRequest>
    {
        public OdjelController(ILogger<BaseController<Odjel, Model.Request.OdjelSearchRequest>> logger, IOdjelService service) : base(logger, service)
        {
        }
    }
}
