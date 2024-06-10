using eKarton.Model.Models;
using eKarton.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eKarton.Controllers
{
    [Route("[controller]")]
    public class PregledController : BaseController<Model.Models.Pregled, Model.Request.PregledSearchRequest>
    {
        public PregledController(ILogger<BaseController<Pregled, Model.Request.PregledSearchRequest>> logger, IPregledService service) : base(logger, service)
        {
        }
    }
}
