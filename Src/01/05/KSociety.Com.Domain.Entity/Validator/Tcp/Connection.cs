using FluentValidation;
using KSociety.Com.Domain.Entity.Tcp;

namespace KSociety.Com.Domain.Entity.Validator.Tcp;

public class Connection : AbstractValidator<TcpConnection>
{
    public Connection()
    {

    }
}