using InterviewTestTemplatev2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewTestTemplatev2.Services.Repostiories
{
    public interface ISynetecService<T> where T : class
    {
        List<T> GetAll();
        T FindById(int id);
    }
    public abstract class SynetecService<T> : ISynetecService<T> where T : class
    {
        protected readonly ISynetecRepository<T> synetecRepository;

        public SynetecService(ISynetecRepository<T> synetecRepository)
        {
            this.synetecRepository = synetecRepository;
        }
        public List<T> GetAll()
        {
            return synetecRepository.GetAll()?.ToList() ?? new List<T>();
        }
        public T FindById(int id)
        {
            return synetecRepository.FindById(id);
        }
    }
}