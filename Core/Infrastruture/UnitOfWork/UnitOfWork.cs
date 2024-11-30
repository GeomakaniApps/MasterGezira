using Core.Infrastruture.RepositoryPattern.Repository;
using DataLayer;
using DataLayer.Helpers;

namespace Core.Infrastruture.UnitOfWork;

public class UnitOfWork(MasterDBContext _dbContext) : IUnitOfWork
{
    private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

    public Dictionary<Type, object> Repositories
    {
        get { return _repositories; }
        set { Repositories = value; }
    }

    public async Task<int> Commit()
        => await _dbContext.SaveChangesAsync();

    public void Rollback()
        => _dbContext.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());

    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public IRepository<T> Repository<T>() where T : Entity
    {
        if (Repositories.Keys.Contains(typeof(T)))
        {
            return Repositories[typeof(T)] as IRepository<T>;
        }

        IRepository<T> repo = new Repository<T>(_dbContext);

        Repositories.Add(typeof(T), repo);
        return repo;
    }

}