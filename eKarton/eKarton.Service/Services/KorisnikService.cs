using AutoMapper;
using eKarton.Model.Models;
using eKarton.Model.Request;
using eKarton.Service.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eKarton.Service.Services
{
    public class KorisnikService : BaseCRUDService<Model.Models.Korisnik, Database.Korisnik, KorisnikSearchRequest, KorisnikInsertRequest, KorisnikUpdateRequest>, IKorisnikService
    {
        public KorisnikService(eKartonContext context, IMapper mapper)
        : base(context, mapper)
        {
        }

        public override async Task BeforeInsert(Database.Korisnik entity, KorisnikInsertRequest insert)
        {
            entity.LozinkaSalt = GenerateSalt();
            entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, insert.Password);
        }


        public static string GenerateSalt()
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            var byteArray = new byte[16];
            provider.GetBytes(byteArray);


            return Convert.ToBase64String(byteArray);
        }
        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }


        public override IQueryable<Database.Korisnik> AddInclude(IQueryable<Database.Korisnik> query, KorisnikSearchRequest? search = null)
        {
            if (search?.IsUlogeIncluded == true)
            {
                query = query.Include("KorisnikUlogas.Uloga");
            }
            return base.AddInclude(query, search);
        }
        public override IQueryable<Database.Korisnik> AddFilter(IQueryable<Database.Korisnik> query, KorisnikSearchRequest? search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (!string.IsNullOrWhiteSpace(search?.ImeKorisnika))
            {
                filteredQuery = filteredQuery.Where(x => x.Ime == search.ImeKorisnika);
            }
            if (!string.IsNullOrWhiteSpace(search?.PrezimeKorisnika))
            {
                filteredQuery = filteredQuery.Where(x => x.Prezime == search.PrezimeKorisnika);
            }

            return filteredQuery;
        }

        public async Task<Model.Models.Korisnik> Login(string username, string password)
        {
            var entity = await _context.Korisniks.Include("KorisnikUlogas.Uloga").FirstOrDefaultAsync(x => x.KorisnickoIme == username);

            if (entity == null)
            {
                return null;
            }

            var hash = GenerateHash(entity.LozinkaSalt, password);

            if (hash != entity.LozinkaHash)
            {
                return null;
            }

            return _mapper.Map<Model.Models.Korisnik>(entity);
        }
    }
}
