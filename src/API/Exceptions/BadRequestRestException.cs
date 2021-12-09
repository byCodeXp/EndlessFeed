using System;

namespace API.Exceptions;

public class BadRequestRestException : Exception
{
    public BadRequestRestException(string message)
        : base(message)
    {
    }
}