using Ardalis.Specification;
using BananaPie.Users.Core;
using System.Linq;

namespace BananaPie.Users.Core.Specifications
{
    public class UserGetByEmailSpecNoTracking : Specification<User>, ISingleResultSpecification
    {
        public UserGetByEmailSpecNoTracking(string emailAddress)
        {
            Query
                .Include(rs => rs.KnownAliases)
                .Where(rs => rs.EmailAddress == emailAddress)
                .AsNoTracking()
                ;
        }
    }
}
