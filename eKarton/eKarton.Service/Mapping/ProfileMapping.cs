using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace eKarton.Service.Mapping
{
    public class ProfileMapping:Profile
    {
         public ProfileMapping() {
            CreateMap<Database.Korisnik, Model.Models.Korisnik>();
            CreateMap<Database.Administrator, Model.Models.Administrator>();
            CreateMap<Database.Bolnica, Model.Models.Bolnica>();
            CreateMap<Database.Odjel, Model.Models.Odjel>();
            CreateMap<Database.Doktor, Model.Models.Doktor>();
            CreateMap<Database.Osiguranje, Model.Models.Osiguranje>();
            CreateMap<Database.Pacijent, Model.Models.Pacijent>();
            CreateMap<Database.Pregled, Model.Models.Pregled>();
            CreateMap<Database.PreventivneMjere, Model.Models.PreventivneMjere>();
            CreateMap<Database.Termin, Model.Models.Termin>();









        }
    }
}
