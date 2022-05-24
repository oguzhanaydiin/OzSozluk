﻿using AutoMapper;
using MediatR;
using OzSozluk.Api.Application.Interfaces.Repositories;
using OzSozluk.Api.Domain.Models;
using OzSozluk.Common.Models.Queries;

namespace OzSozluk.Api.Application.Features.Queries.GetUserDetail;

public class GetUserDetailQueryHandler : IRequestHandler<GetUserDetailQuery, UserDetailViewModel>
{
    private readonly IUserRepository userRepository;
    private readonly IMapper mapper;

    public GetUserDetailQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        this.userRepository = userRepository;
        this.mapper = mapper;
    }

    public async Task<UserDetailViewModel> Handle(GetUserDetailQuery request, CancellationToken cancellationToken)
    {
        User dbUser = null;

        if (request.UserId != Guid.Empty)
        {
            dbUser = await userRepository.GetByIdAsync(request.UserId);
        }
        else if (!string.IsNullOrEmpty(request.UserName))
        {
            dbUser = await userRepository.GetSingleAsync(i => i.UserName == request.UserName);
        }

        return mapper.Map<UserDetailViewModel>(dbUser);
    }
}
