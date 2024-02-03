using Domain.Entities;
using Domain.Requests;
using Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validators;

public class UserValidator: IValidator<BaseUserRequest>
{
    public List<ErrorMessageResponse> Validate(BaseUserRequest user)
    {
        var errors= new List<ErrorMessageResponse>();
        if(string.IsNullOrEmpty(user.Name))
        {
            errors.Add(new ErrorMessageResponse
            {
                Field = "Name",
                Message= "Field is Required"
            });                
        }
        if (string.IsNullOrEmpty(user.Email))
        {
            errors.Add(new ErrorMessageResponse
            {
                Field = "Email",
                Message = "Field is Required"
            });
        }
        if (string.IsNullOrEmpty(user.Password))
        {
            errors.Add(new ErrorMessageResponse
            {
                Field = "Password",
                Message = "Field is Required"
            });
        }
        return errors;
    }
}
