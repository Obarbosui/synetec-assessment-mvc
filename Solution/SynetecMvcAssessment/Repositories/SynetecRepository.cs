using InterviewTestTemplatev2.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InterviewTestTemplatev2.Repositories
{
    public interface ISynetecRepository<T> where T:class
    {
        IEnumerable<T> GetAll();
        T FindById(int id);
    }
    public abstract class SynetecRepository<T> : ISynetecRepository<T> where T:class
    {
        private readonly MvcInterviewV3Entities1 context;
        protected DbSet<T> dbSet;

        public SynetecRepository(MvcInterviewV3Entities1 context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }
        public T FindById(int id)
        {
            return dbSet.Find(id);
        }
    }
}