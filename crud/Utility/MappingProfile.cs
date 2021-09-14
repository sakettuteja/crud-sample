using AutoMapper;
using crud.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud.Utility
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Register, User>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email))
                .ForMember(u=> u.PasswordHash, opt=> opt.MapFrom(x=>x.Password));
        }
    }
}
