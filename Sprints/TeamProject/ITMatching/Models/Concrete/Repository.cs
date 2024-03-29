﻿using ITMatching.Models.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITMatching.Models.Concrete
{

    /// Base class repository that implements only CRUD operations.  Meant to be like an abstract 
    /// base class, but not actually made abstract because it may be useful to have a repository 
    /// that only supports crud.
    /// 
    /// This is only a minimal version. There is quite a lot we could add to this, including:
    ///    - add better error checking/recovery (i.e. throw exceptions when something goes wrong)
    ///    - Write a base model class for the parameterized type, i.e. require TEntity : ModelBase, 
    ///      and have ModelBase define important things like the PK name and type so we can enforce that in
    ///      FindById for example.
    ///    - Non async versions
    ///    - As Baltazar suggested during class, add a method called something like GetFiltered that takes Func delegate
    ///      and allows us to apply a filter like Where when getting an IQueryable of TEntity.

 
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {

        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(DbContext ctx)
        {
            _context = ctx;
            _dbSet = _context.Set<TEntity>();   // must do it this way because we don't have a "navigation property" to use
        }

        public virtual async Task<TEntity> FindByIdAsync(int id)
        {
            TEntity entity = await _dbSet.FindAsync(id);
            return entity; 
        }

        public virtual async Task<bool> ExistsAsync(int id)
        {
            return await FindByIdAsync(id) != null;
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public virtual async Task<TEntity> AddOrUpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity must not be null to add or update");
            }
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new Exception("Entity to delete was null");
            }
            else
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
            return;
        }

        public virtual async Task DeleteByIdAsync(int id)
        {
            await DeleteAsync(await FindByIdAsync(id));
            return;
        }
    }
}
