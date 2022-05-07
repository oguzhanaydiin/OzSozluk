using MediatR;
using OzSozluk.Api.Application.Interfaces.Repositories;
using OzSozluk.Common.Events.User;
using OzSozluk.Common.Infrastructure;
using OzSozluk.Common.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzSozluk.Api.Application.Features.Commands.User.ChangePassword;

public class ChangeUserPasswordCommandHandler : IRequestHandler<ChangeUserPasswordCommand, bool>
{
    private readonly IUserRepository userRepository;

    public ChangeUserPasswordCommandHandler(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public async Task<bool> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
    {
        if (!request.UserId.HasValue)
        {
            throw new ArgumentNullException(nameof(request.UserId));
        }
        var dbUser = await userRepository.GetByIdAsync(request.UserId.Value);

        if (dbUser == null)
        {
            throw new DatabaseValidationException("User Not Found!");
        }

        var encryptedPassword = PasswordEncryptor.Encrypt(request.OldPassword);

        if (dbUser.Password != encryptedPassword)
        {
            throw new DatabaseValidationException("Old Password Wrong!");
        }

        dbUser.Password = encryptedPassword;

        await userRepository.UpdateAsync(dbUser);

        return true;
    }
}
