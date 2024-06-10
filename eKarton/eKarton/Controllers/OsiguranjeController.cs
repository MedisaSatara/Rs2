using eKarton.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eKarton.Controllers
{
    [Route("[controller]")]
    public class OsiguranjeController : BaseCRUDController<Model.Models.Osiguranje, Model.Request.OsiguranjeSearchRequest, Model.Request.OsiguranjeInsertRequest, Model.Request.OsiguranjeUpdateRequest>
    {
        public OsiguranjeController(ILogger<BaseController<Model.Models.Osiguranje, Model.Request.OsiguranjeSearchRequest>> logger, IOsiguranjeService service) : base(logger, service)
        {
        }

    }
}
