using Domain.Exceptions;
using Domain.Responses;
using Domain.Validators;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services;

public interface IAuthService
{
    string SignIn(AuthRequest request);
}

public class AuthService : IAuthService
{

    private readonly IUserRepository _repository;
    private readonly IHashingService _hashingService;
    private readonly IJwtService _jwtService;
    private const string InvalidLoginMessage = "Login is invalid";

    public AuthService(IUserRepository repository,IHashingService hashingService, IJwtService jwtService)
    {
        _repository = repository;
        _hashingService = hashingService;
        _jwtService= jwtService;
    }
    public string SignIn(AuthRequest request)
    {
        var user = _repository.FindByEmail(request.Email!);
        if (user is null)
            throw new UnauthorizedException(InvalidLoginMessage);

        bool passwordIsValid = _hashingService.Verify(request.Password!, user.Password!);

        if (!passwordIsValid)
            throw new UnauthorizedException(InvalidLoginMessage);
        var jwt = _jwtService.CreateToken(user);
        return new AuthResponse
        {
            Token = jwt,
    };
    }
}
