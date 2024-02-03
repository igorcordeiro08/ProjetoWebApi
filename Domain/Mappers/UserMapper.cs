using Domain.Entities;
using Domain.Requests;
using Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mappers
{
    public static class UserMapper
    {
        public static UserResponse ToResponse(User user) => new UserResponse
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            
        };
        public static User ToEntity(BaseUserRequest user) => new User
        {
            
            Name = user.Name,
            Email = user.Email,
            Password = user.Password
        };
        public static User ToEntity(UpdateUserRequest user) => new User
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Password = user.Password
        };
    }
}
