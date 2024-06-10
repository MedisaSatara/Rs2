using eKarton.Model.Request;
using eKarton.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eKarton.Controllers
{
    [Route("[controller]")]
    public class PacijentController : BaseCRUDController<Model.Models.Pacijent, Model.Request.PacijentSearchRequest, Model.Request.PacijentInsertRequest, Model.Request.PacijentUpdateRequest>
    {
        public PacijentController(ILogger<BaseController<Model.Models.Pacijent, Model.Request.PacijentSearchRequest>> logger, IPacijentService service) : base(logger, service)
        {
        }

        public override Task<Model.Models.Pacijent> Insert([FromBody] PacijentInsertRequest insert)
        {
            return base.Insert(insert);
        }

    }
}
