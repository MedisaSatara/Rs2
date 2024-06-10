using eKarton.Model.Models;
using eKarton.Model.Request;
using eKarton.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eKarton.Controllers
{
    [Route("[controller]")]
    public class BolnicaController : BaseController<Model.Models.Bolnica, BaseSearchObject>
    {
        public BolnicaController(ILogger<BaseController<Bolnica, BaseSearchObject>> logger, IBolnicaService service) : base(logger, service)
        {
        }
    }
}
