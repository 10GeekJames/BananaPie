using BananaPie.Users.Core;
using MediatR;

namespace BananaPie.Users.Infrastructure.Commands
{
    public class UserKnownAliasCreateCommand : IRequest<KnownAlias>
    {
        public string EmailAddress { get; init; }
        public string UserAlias { get; init; }

        public UserKnownAliasCreateCommand(string emailAddress, string userAlias)
        {
            EmailAddress = emailAddress;
            UserAlias = userAlias;
        }
    }
}