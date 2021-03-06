using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Repository.Context;
using Repository.Interfaces;
using Repository.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repository.Repositories.Common
{
    public class Repository<IEntity> : IRepository<IEntity> where IEntity : class 
    {
        #region [Context]
        protected CVManagerContext Context;
        #endregion

        public Repository(CVManagerContext context)
        {
            Context = context;
        }

        #region Get
        public IEntity Get(long Id)
        {
            /* IEntity result = Context.Set<IEntity>().AsNoTracking().FirstOrDefault(entity => entity.Id == Id);
             return result;*/
            throw new Exception("has");
        }

        #endregion

        #region GetAll
        public IEnumerable<IEntity> GetAll()
        {
                IQueryable<IEntity> dbQuery = Context.Set<IEntity>();
                return dbQuery.AsNoTracking();         
        }

        #endregion

        #region FirstOrDefault
        public IEntity FirstOrDefault(Expression<Func<IEntity, bool>> where, params Expression<Func<IEntity, object>>[] navigationProperties)
        {
            IQueryable<IEntity> dbQuery = Context.Set<IEntity>();

            foreach (Expression<Func<IEntity, object>> navigationProperty in navigationProperties)
            {
                dbQuery = dbQuery.Include<IEntity, object>(navigationProperty);
            }

            return dbQuery.Where(where).FirstOrDefault();
        }
        #endregion

        #region Find
        public IEnumerable<IEntity> Find(Expression<Func<IEntity, bool>> predicate, params Expression<Func<IEntity, object>>[] navigationProperties)
        {
            IQueryable<IEntity> dbQuery = Context.Set<IEntity>();

            foreach (Expression<Func<IEntity, object>> navigationProperty in navigationProperties)
            {
                dbQuery = dbQuery.Include<IEntity, object>(navigationProperty);
            }

            return dbQuery.Where(predicate).AsNoTracking();
        }
        #endregion

        #region Add
        public IEntity Add(IEntity entity)
        {
            Context.Set<IEntity>().Add(entity);
            SaveChanges();
            Context.Entry(entity).GetDatabaseValues();
            return entity;
        }
        #endregion

        #region AddRnage
        public IEnumerable<IEntity> AddRange(IEnumerable<IEntity> entities)
        {
            Context.ChangeTracker.Entries<IEntity>();
            Context.Set<IEntity>().AddRange(entities);
            SaveChanges();
            return entities;
        }
        #endregion

        #region Update
        public IEntity Update(IEntity entity, bool disableAttach = false)
        {
            
                Context.Set<IEntity>().Update(entity);
                Context.Entry(entity).State = EntityState.Modified;
                SaveChanges();
                return entity;
        }
        #endregion

        #region UpdateRange
        public IEnumerable<IEntity> UpdateRange(IEnumerable<IEntity> Entities)
        {
            

            Context.Set<IEntity>().UpdateRange(Entities);
            SaveChanges();
            return Entities;
        }
        #endregion

        #region Remove
        public IEntity Remove(IEntity entity)
        {
            Context.Set<IEntity>().Remove(entity);
            SaveChanges();
            return entity;
        }
        #endregion

        #region RemoveRange
        public IEnumerable<IEntity> RemoveRange(IEnumerable<IEntity> entities)
        {
            

            Context.Set<IEntity>().RemoveRange(entities);
            SaveChanges();
            return entities;
        }
        #endregion

        #region SaveChanges
        public void SaveChanges()
        {
            Context.SaveChanges();
        }
        #endregion

        #region BeginTransaction
        public IDbContextTransaction BeginTransaction()
        {
            return Context.Database.BeginTransaction();
        }
        #endregion

        #region CommitTransaction
        public void CommitTransaction()
        {
            Context.Database.CommitTransaction();
        }
        #endregion

        #region RollbackTransaction
        public void RollbackTransaction()
        {
            Context.Database.RollbackTransaction();
        }

        #endregion

        public bool Any(Expression<Func<IEntity, bool>> where)
        {
            return Context.Set<IEntity>().Any(where);
        }

        public int Count(Expression<Func<IEntity, bool>> where)
        {
            return Context.Set<IEntity>().Where(where).Count();
        }

    }
}
