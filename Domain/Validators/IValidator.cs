using Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validators;

public interface IValidator<T>
{
    public List<ErrorMessageResponse> Validate(T obj);
}
