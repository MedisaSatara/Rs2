using eKarton.Model.Request;
using eKarton.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eKarton.Controllers
{
    [Route("[controller]")]
    public class TerminController : BaseCRUDController<Model.Models.Termin, Model.Request.TerminSearchRequest, Model.Request.TerminInsertRequest, Model.Request.TerminUpdateRequest>
    {
        public TerminController(ILogger<BaseController<Model.Models.Termin, Model.Request.TerminSearchRequest>> logger, ITerminService service) : base(logger, service)
        {
        }

        public override Task<Model.Models.Termin> Insert([FromBody] TerminInsertRequest insert)
        {
            return base.Insert(insert);
        }

    }
}
