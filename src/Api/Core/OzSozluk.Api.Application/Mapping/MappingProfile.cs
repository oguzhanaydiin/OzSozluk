﻿using AutoMapper;
using OzSozluk.Api.Domain.Models;
using OzSozluk.Common.Models.Queries;
using OzSozluk.Common.Models.RequestModels;

namespace OzSozluk.Api.Application.Mapping;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, LoginUserViewModel>()
            .ReverseMap();

        CreateMap<CreateUserCommand, User>();

        CreateMap<UpdateUserCommand, User>();

        CreateMap<CreateEntryCommand, Entry>()
            .ReverseMap();

        CreateMap<Entry, GetEntriesViewModel>()
            .ForMember(x => x.CommentCount, y => y.MapFrom(z => z.EntryComments.Count));


        CreateMap<CreateEntryCommentCommand, EntryComment>()
            .ReverseMap();
    }
}