using System;
using System.Collections.Generic;
using IFExperiment.Shared.Entities;

namespace IFExperiment.Domain.ExperimentContext.Repositorio
{
    public interface IRepositorio<T> : IDisposable where T : EntityBase
    {
        
        T GetByIdTracking(Guid id, string[] includes = null);
        T GetByIdTracking(Guid id);
        void Save(T obj);
        void Save(IList<T> obj);
        void Update(T obj);
        void Delete(Guid id);
    }
}
