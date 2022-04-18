using BananaPie.Users.Core;
using MediatR;

namespace BananaPie.Users.Infrastructure.Queries
{
    public class GetUserByEmailQuery : IRequest<User>
    {
        public string EmailAddress { get; set; }
        
        public GetUserByEmailQuery(){}
        public GetUserByEmailQuery(string emailAddress)
        {
            EmailAddress = emailAddress;
        }        
    }
}