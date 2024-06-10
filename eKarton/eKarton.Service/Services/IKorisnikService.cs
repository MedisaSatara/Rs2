using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKarton.Service.Services
{
    public interface IKorisnikService : ICRUDService<Model.Models.Korisnik, Model.Request.KorisnikSearchRequest, Model.Request.KorisnikInsertRequest, Model.Request.KorisnikUpdateRequest>
    {
        public Task<Model.Models.Korisnik> Login(string username, string password);
    }
}
