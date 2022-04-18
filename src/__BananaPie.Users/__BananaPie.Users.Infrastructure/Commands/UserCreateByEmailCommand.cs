using BananaPie.Users.Core;
using MediatR;

namespace BananaPie.Users.Infrastructure.Commands
{
    public class UserCreateByEmailCommand : IRequest<User>
    {
        public string EmailAddress { get; init; }

        public UserCreateByEmailCommand(string emailAddress)
        {
            EmailAddress = emailAddress;
        }
    }
}