using Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions;

public class UnauthorizedException: Exception
{
   public UnauthorizedException(string message) : base(message)
    {

    }
    public int StatusCode { get => 40; }

}
