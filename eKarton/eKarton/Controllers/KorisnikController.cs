using eKarton.Model.Request;
using eKarton.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eKarton.Controllers
{
    [Route("[controller]")]
    public class KorisnikController : BaseCRUDController<Model.Models.Korisnik, Model.Request.KorisnikSearchRequest, Model.Request.KorisnikInsertRequest, Model.Request.KorisnikUpdateRequest>
    {
        public KorisnikController(ILogger<BaseController<Model.Models.Korisnik, Model.Request.KorisnikSearchRequest>> logger, IKorisnikService service) : base(logger, service)
        {
        }
        [Authorize(Roles = "Administrator")]
        public override Task<Model.Models.Korisnik> Insert([FromBody] KorisnikInsertRequest insert)
        {
            return base.Insert(insert);
        }

    }
}
