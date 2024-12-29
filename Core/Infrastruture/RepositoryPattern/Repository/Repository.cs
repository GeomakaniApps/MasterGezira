using Core.Infrastruture.UnitOfWork;
using DataLayer;
using DataLayer.Helpers;
using DataLayer.Services.Pagination;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Infrastruture.RepositoryPattern.Repository;

public class Repository<T> : IRepository<T> where T : Entity
{
    private readonly MasterDBContext _dbContext;
    private readonly DbSet<T> _dbSet;
    private readonly IUnitOfWork _unitOfWork;

    public Repository(MasterDBContext context)
    {
        _dbContext = context;
        _dbSet = _dbContext.Set<T>();
        _unitOfWork = new UnitOfWork.UnitOfWork(context);
    }

    public IQueryable<T> Query()
        => _dbContext.Set<T>().AsQueryable();

    public ICollection<T> GetAll()
         => _dbContext.Set<T>().ToList();

    public ICollection<T> GetAll(string includeProperties = "")
    {
        IQueryable<T> query = _dbContext.Set<T>();
        foreach (
        var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }
        return query.ToList();
    }

    public async Task<ICollection<T>> GetAllAsync()
       => await _dbContext.Set<T>().ToListAsync();
    public async Task<ICollection<T>> GetAllAsync(string includeProperties = "")
    {
        IQueryable<T> query = _dbContext.Set<T>();
        foreach (
        var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }
        return await query.ToListAsync();
    }
    public async Task<T> GetByIdAsync(object id, string includeProperties = "")
    {
        IQueryable<T> query = _dbContext.Set<T>();

        foreach (var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }

        
        return await query.FirstOrDefaultAsync(e => EF.Property<object>(e, "Id").Equals(id));
    }
#pragma warning disable CS8603 // Possible null reference return.
    public T GetById(int id)
        => _dbContext.Set<T>().Find(id);

    public async Task<T> GetByIdAsync(int id)
        => await _dbContext.Set<T>().FindAsync(id);

    public T GetByUniqueId(Guid id)
        => _dbContext.Set<T>().Find(id);

    public async Task<T> GetByUniqueIdAsync(Guid id)
        => await _dbContext.Set<T>().FindAsync(id);

    public T Find(Expression<Func<T, bool>> match)
        => _dbContext.Set<T>().SingleOrDefault(match);

    public async Task<T> FindAsync(Expression<Func<T, bool>> match)
        => await _dbContext.Set<T>().SingleOrDefaultAsync(match);

    public ICollection<T> FindAll(Expression<Func<T, bool>> match)
        => _dbContext.Set<T>().Where(match).ToList();

    public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match, string includeProperties = "")
    {
        IQueryable<T> query = _dbContext.Set<T>().Where(match);
        foreach (
        var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }
        return await query.ToListAsync();
    }

    public T Add(T entity)
    {
        _dbContext.Set<T>().Add(entity);
        _dbContext.SaveChanges();
        return entity;
    }

    public async Task<T> AddAsync(T entity)
    {
        _dbContext.Set<T>().Add(entity);
        await _unitOfWork.Commit();
        return entity;
    }

    public T Update(T updated)
    {
        if (updated is null)
        {
            return null;
        }

        _dbContext.Set<T>().Attach(updated);
        _dbContext.SaveChanges();

        return updated;
    }

    public async Task<T> UpdateAsync(T updated)
    {
        if (updated is null)
        {
            return null;
        }

        _dbContext.Set<T>().Attach(updated);
        await _unitOfWork.Commit();

        return updated;
    }

    public void Delete(T t)
    {
        _dbContext.Set<T>().Remove(t);
        _dbContext.SaveChanges();
    }

    public async Task<int> DeleteAsync(T t)
    {
        _dbContext.Set<T>().Remove(t);
        return await _unitOfWork.Commit();
    }

    public int Count()
        => _dbContext.Set<T>().Count();

    public async Task<int> CountAsync()
        => await _dbContext.Set<T>().CountAsync();

    public IEnumerable<T> Filter(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string includeProperties = "", int? page = null,
        int? pageSize = null)
    {
        IQueryable<T> query = _dbContext.Set<T>();
        if (filter is not null)
        {
            query = query.Where(filter);
        }

        if (orderBy is not null)
        {
            query = orderBy(query);
        }

        if (includeProperties is not null)
        {
            foreach (
                var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
        }

        if (page is not null && pageSize is not null)
        {
            query = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);
        }

        return query.ToList();
    }

    public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        => _dbContext.Set<T>().Where(predicate);

    public bool Exist(Expression<Func<T, bool>> predicate)
    {
        var exist = _dbContext.Set<T>().Where(predicate);
        return exist.Any();
    }

    //////////////////////////////////////Another Type from Function////////////////////////////////////////////

    public IEnumerable<T> GetAll1()
      => _dbSet.AsEnumerable();

    public T Get(int id)
      => _dbContext.Set<T>().Find(id);

    public void Insert(T entity)
    {
        if (entity is null)
        {
            throw new NotImplementedException("entity");
        }
        _dbSet.Add(entity);
        _dbContext.SaveChanges();
    }

    public void Update1(T entity)
    {
        if (entity is null)
        {
            throw new NotImplementedException("entity is null");
        }
        _dbSet.Update(entity);
        _dbContext.SaveChanges();
    }

    public void Delete1(T entity)
    {
        if (entity is null)
        {
            throw new NotImplementedException("entity is null");
        }
        _dbSet.Remove(entity);
        _dbContext.SaveChanges();
    }

    public void Remove(T entity)
    {
        if (entity is null)
        {
            throw new NotImplementedException("entity is null");
        }
        _dbSet.Remove(entity);

    }

    public void SaveChanges()
      => _dbContext.SaveChanges();

    public async Task SaveChangesAsync()
      => await _dbContext.SaveChangesAsync();

    public int SaveChangesTracker()
      => _dbContext.SaveChanges();

    public void RemoveRange(IEnumerable<T> entity)
    {
        if (entity is null)
        {
            throw new NotImplementedException("entity is null");
        }
        _dbSet.RemoveRange(entity);
    }

    public async Task RemoveRangeAsync(IEnumerable<T> entities)
    {
        if (entities is null)
        {
            throw new NotImplementedException("entity is null");
        }
        _dbSet.RemoveRange(entities);
        await _dbContext.SaveChangesAsync();
    }

    public void AddRange(IEnumerable<T> entities)
    {
        _dbSet.AddRange(entities);
        _dbContext.SaveChanges();
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await _dbSet.AddRangeAsync(entities);
        await _dbContext.SaveChangesAsync();
    }

    public void UpdateRange(IEnumerable<T> entities)
    {
        _dbSet.UpdateRange(entities);
        _dbContext.SaveChanges();
    }

    public async Task UpdateRangeAsync(IEnumerable<T> entities)
    {
        _dbSet.UpdateRange(entities);
        await _dbContext.SaveChangesAsync();
    }
    public async Task<T> FindLastAsync(string propertyName)
    {
        return await _dbContext.Set<T>()
            .OrderByDescending(m => EF.Property<object>(m, propertyName)) 
            .FirstOrDefaultAsync();
    }
    public async Task<bool> ValidateExistenceAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.AnyAsync(predicate);
    }

#pragma warning restore CS8603 // Possible null reference return.

    #region Filter All

    public async Task<PagedList<PaginationRequest<T>>> FilterAll(
          List<FilterDTO> filterDTOs,
          UserParams userParams,
          List<string>? includeProperties = null,
          Dictionary<string, List<string>>? thenIncludeProperties = null)
    {
        //  IQueryable<T> query = _dbSet;
        IQueryable<T> query = _dbContext.Set<T>();

        if (filterDTOs == null || !filterDTOs.Any())
            throw new Exception("Please provide valid filter conditions");

        var entityType = typeof(T);
        var parameter = Expression.Parameter(entityType, "n");

        foreach (var filterDTO in filterDTOs)
        {
            if (string.IsNullOrEmpty(filterDTO.PropertyName) || string.IsNullOrEmpty(filterDTO.PropertyValue))
                throw new Exception("Please enter valid values for PropertyName and PropertyValue");

            filterDTO.PropertyName = char.ToUpper(filterDTO.PropertyName[0]) + filterDTO.PropertyName.Substring(1);
            var propertyNames = filterDTO.PropertyName.Split('.');
            Expression propertyExpression = parameter;

            foreach (var propertyName in propertyNames)
            {
                propertyExpression = Expression.Property(propertyExpression, propertyName);
            }

            var propertyType = propertyExpression.Type;
            if (propertyType == null)
                throw new Exception($"Invalid PropertyName: {filterDTO.PropertyName}");

            object startValue = null, endValue = null;

            if (filterDTO.Range && !string.IsNullOrEmpty(filterDTO.PropertyValue))
            {
                var rangeValues = filterDTO.PropertyValue.Split(',');
                if (rangeValues.Length == 2)
                {
                    startValue = ProcessValue(rangeValues[0], propertyType);
                    endValue = ProcessValue(rangeValues[1], propertyType);

                    var startConstant = Expression.Constant(startValue, propertyType);
                    var endConstant = Expression.Constant(endValue, propertyType);

                    var startPredicate = Expression.GreaterThanOrEqual(propertyExpression, startConstant);
                    var endPredicate = Expression.LessThanOrEqual(propertyExpression, endConstant);

                    var combinedPredicate = Expression.AndAlso(startPredicate, endPredicate);
                    var lambda = Expression.Lambda<Func<T, bool>>(combinedPredicate, parameter);

                    query = query.Where(lambda);
                }
                else
                {
                    throw new Exception("Range filter requires two values separated by a comma.");
                }
            }
            else
            {
                var convertedValue = ProcessValue(filterDTO.PropertyValue, propertyType);

                var constant = Expression.Constant(convertedValue, propertyType);
                var predicate = Expression.Equal(propertyExpression, constant);
                var lambda = Expression.Lambda<Func<T, bool>>(predicate, parameter);

                query = query.Where(lambda);

                //var convertedValue = ConvertToType(filterDTO.PropertyValue, propertyType);
                // var constant = Expression.Constant(convertedValue, propertyType);
                // var predicate = Expression.Equal(propertyExpression, constant);
                // var lambda = Expression.Lambda<Func<T, bool>>(predicate, parameter);

                // // Apply filter to the query
                // query = query.Where(lambda);



            }
        }

        if (includeProperties != null)
        {
            foreach (var prop in includeProperties)
            {
                foreach (var item in prop.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    query = query.Include(item);
            }
        }

        if (thenIncludeProperties != null)
        {
            foreach (var includeProperty in thenIncludeProperties)
            {
                query = ApplyThenInclude(query, includeProperty.Key, includeProperty.Value);
            }
        }

        if (!query.Any())
            throw new Exception("Didn't find any data");

        var items = await PagedList<T>.CreateAsync(query, userParams.PageNumber, userParams.PageSize);
        var totalCount = await query.CountAsync();

        var paginationRequests = query
            .Select(item => new PaginationRequest<T>
            {
                Data = item,
                Count = totalCount
            });

        return await PagedList<PaginationRequest<T>>.CreateAsync(paginationRequests, userParams.PageNumber, userParams.PageSize);
    }
    private static IQueryable<T> ApplyThenInclude(IQueryable<T> query, string propertyName, List<string> thenIncludeProperties)
    {
        foreach (var thenIncludeProperty in thenIncludeProperties)
        {
            query = query.Include($"{propertyName}.{thenIncludeProperty}");
        }
        return query;
    }

    private static object ProcessValue(string value, Type targetType)
    {
        if (string.IsNullOrEmpty(value))
            throw new ArgumentException("Value cannot be null or empty.", nameof(value));

        //if (Nullable.GetUnderlyingType(targetType) != null)
        //{
        //    var underlyingType = Nullable.GetUnderlyingType(targetType);

        //    if (string.IsNullOrWhiteSpace(value))
        //        return null;

        //    return Convert.ChangeType(value, underlyingType!);
        //}

        if (targetType == typeof(DateTime) || targetType == typeof(DateTime?))
        {
            if (DateTime.TryParse(value, out var dateValue))
            {
                return dateValue.Kind == DateTimeKind.Utc ? dateValue : dateValue.ToUniversalTime();
            }
            throw new Exception("Invalid date format.");
        }

        if (targetType == typeof(DateOnly) || targetType == typeof(DateOnly?))
        {
            if (DateOnly.TryParse(value, out var dateOnlyValue))
            {
                return dateOnlyValue;
            }
            throw new Exception("Invalid date format.");
        }

        return Convert.ChangeType(value, targetType);
    }





    #endregion

}