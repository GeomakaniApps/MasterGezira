using Core.Infrastruture.RepositoryPattern.Repository;
using DataLayer.Helpers;

namespace Core.Infrastruture.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IRepository<T> Repository<T>() where T : Entity;

    Task<int> Commit();

    void Rollback();
}
