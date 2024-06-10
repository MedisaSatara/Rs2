using eKarton.Model.Request;
using eKarton.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eKarton.Controllers
{
    [Route("[controller]")]
    public class PreventivneMjereController : BaseCRUDController<Model.Models.PreventivneMjere, Model.Request.PreventivneMjereSearchRequest, Model.Request.PreventivneMjereInsertRequest, Model.Request.PreventivneMjereUpdateRequest>
    {
        public PreventivneMjereController(ILogger<BaseController<Model.Models.PreventivneMjere, Model.Request.PreventivneMjereSearchRequest>> logger, IMjereService service) : base(logger, service)
        {
        }

        public override Task<Model.Models.PreventivneMjere> Insert([FromBody] PreventivneMjereInsertRequest insert)
        {
            return base.Insert(insert);
        }


    }
}
