using AutoMapper;
using eKarton.Model.Request;
using eKarton.Service.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eKarton.Service.Services
{
    public class PacijentService : BaseCRUDService<Model.Models.Pacijent, Database.Pacijent, PacijentSearchRequest, PacijentInsertRequest, PacijentUpdateRequest>, IPacijentService
    {
        public PacijentService(eKartonContext context, IMapper mapper)
        : base(context, mapper)
        {
        }

        public override async Task BeforeInsert(Database.Pacijent entity, PacijentInsertRequest insert)
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


        public override IQueryable<Database.Pacijent> AddInclude(IQueryable<Database.Pacijent> query, PacijentSearchRequest? search = null)
        {
            if (search?.isPreventivneMjereIncluded == true)
            {
                query = query.Include("PreventivneMjeres");
            }
            if (search?.isOsiguranjeInclude == true)
            {
                query = query.Include("PacijentOsiguranjes.Osiguranje");
            }
            return base.AddInclude(query, search);
        }
        public override IQueryable<Database.Pacijent> AddFilter(IQueryable<Database.Pacijent> query, PacijentSearchRequest? search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (!string.IsNullOrWhiteSpace(search?.ImePacijenta))
            {
                filteredQuery = filteredQuery.Where(x => x.Ime == search.ImePacijenta);
            }
            if (!string.IsNullOrWhiteSpace(search?.PrezimePacijenta))
            {
                filteredQuery = filteredQuery.Where(x => x.Prezime == search.PrezimePacijenta);
            }
            if (!string.IsNullOrWhiteSpace(search?.BrojKartona))
            {
                filteredQuery = filteredQuery.Where(x => x.BrojKartona == search.BrojKartona);
            }
            if (search?.isPreventivneMjereIncluded == true)
            {
                query = query.Include(x => x.PreventivneMjeres);
            }


            return filteredQuery;
        }

    }
}
