using AutoMapper;
using OzSozluk.Api.Domain.Models;
using OzSozluk.Common.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzSozluk.Api.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, LoginUserViewModel>()   //aynı olan isimdeki propları birbirine atayacak
            .ReverseMap();
    }
}
