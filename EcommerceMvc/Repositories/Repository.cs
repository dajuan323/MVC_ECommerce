
using EcommerceMvc.Data;
using Microsoft.EntityFrameworkCore;

namespace EcommerceMvc.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected ApplicationDbContext _context { get; set; }
    private DbSet<T> _dbSet {  get; set; }

    public Repository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }
    public Task AddAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id, QueryOptions<T> options)
    {
        IQueryable<T> query = _dbSet;
        if (options.HasWhere)
            query = query.Where(options.Where);
        if (options.HasOrderBy)
            query = query.OrderBy(options.OrderBy);
        foreach(string include in options.GetIncudes())
            query = query.Include(include);

        var key = _context.Model?.FindEntityType(typeof(T))?.FindPrimaryKey()?.Properties.FirstOrDefault();
        string primaryKeyName = key?.Name!;
        return await query.FirstOrDefaultAsync(_ => EF.Property<int>(_, primaryKeyName) == id);
    }

    public Task UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }
}
