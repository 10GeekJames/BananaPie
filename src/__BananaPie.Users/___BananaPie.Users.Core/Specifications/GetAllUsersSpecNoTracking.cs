using Ardalis.Specification;
using BananaPie.Users.Core;
using System.Linq;

namespace BananaPie.Users.Core.Specifications
{
    public class GetAllUsersSpecNoTracking : Specification<User>
    {
        public GetAllUsersSpecNoTracking()
        {
            Query
                .Include(rs => rs.KnownAliases)
                .Take(int.MaxValue)
                .AsNoTracking()
                ;
        }
    }
}
