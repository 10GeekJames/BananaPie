using Ardalis.Specification;

namespace BananaPie.Kernel.Interfaces
{
    public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
    {
    }
}