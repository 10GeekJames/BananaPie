using BananaPie.Users.Core;
using MediatR;

namespace BananaPie.Users.Infrastructure.Queries
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public Guid Id { get; set; }

        public GetUserByIdQuery() { }

        public GetUserByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}