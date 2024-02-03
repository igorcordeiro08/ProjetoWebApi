using Domain.Entities;
using Domain.Exceptions;
using Domain.Mappers;
using Domain.Requests;
using Domain.Responses;
using Domain.Validators;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services;
public interface IUserServices
{
    List<UserResponse> List();
    UserResponse? GetById(int id);
    UserResponse Create(BaseUserRequest newUser);
    UserResponse Update(UpdateUserRequest newUser);

    //UserResponse Update(int id,User newUser);
    void Delete(int id);



}

public class UserServices: IUserServices
{
    private readonly IValidator<BaseUserRequest> _validator;
    private readonly IUserRepository _repository;
    private readonly IHashingService _hashingService;

    public UserServices(IUserRepository repository, IValidator<BaseUserRequest> validator, IHashingService hashingService)
    {
        _validator = validator;
        _repository = repository;   
        _hashingService= hashingService;
    }
    public List<UserResponse> List()
    {
        var users= _repository.List();
        var respoonse=users.Select(user=>UserMapper.ToResponse(user)).ToList();
        return respoonse;
    }
    public UserResponse? GetById(int id)
    {
        var user= _repository.GetById(id);
        return user is null ? null : UserMapper.ToResponse(user);
    }

    public UserResponse Create(BaseUserRequest request)
    {
        var errors= _validator.Validate(request);
        if (errors.Any())
            throw new BadRequestException(errors);

        var newUser = UserMapper.ToEntity(request);
        newUser.Password = _hashingService.Hash(newUser.Password!);
        var user= _repository.Create(newUser);
        return UserMapper.ToResponse(user);
    }

    
    public UserResponse Update(UpdateUserRequest request)
    {
        var errors = _validator.Validate(request);
        if (errors.Any())
            throw new BadRequestException(errors);

        var newUser = UserMapper.ToEntity(request);
        newUser.Password = _hashingService.Hash(newUser.Password!);
        var user = _repository.Update(newUser);
        //var user= _repository.Update(id,newUser);
        return UserMapper.ToResponse(user);
    }

    public void Delete(int id)
    {
        
        _repository.Delete(id);
    }
}

