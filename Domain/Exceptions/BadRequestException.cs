using Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions;

public class BadRequestException: Exception
{
    private List<ErrorMessageResponse> Errors { get; }

    public BadRequestException(List<ErrorMessageResponse> errors): base()
    {
        Errors = errors;
    }

}
