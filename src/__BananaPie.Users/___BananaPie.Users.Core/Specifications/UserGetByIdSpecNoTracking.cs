using Ardalis.Specification;
using BananaPie.Users.Core;
using System.Linq;

namespace BananaPie.Users.Core.Specifications
{
    public class UserGetByIdSpecNoTracking : Specification<User>, ISingleResultSpecification
    {
        public UserGetByIdSpecNoTracking(Guid id)
        {
            Query
                .Include(rs => rs.KnownAliases)
                .Where(rs => rs.Id == id)
                .AsNoTracking()
                ;
        }
    }
}
