using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using IFExperiment.Shared.Entities;

namespace IFExperiment.Domain.ExperimentContext.Repositorio
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public interface IRepositorio<TEntity, TResponse> : IDisposable
        where TEntity : EntityBase
        where TResponse : EntityResponse
    {

        TEntity GetByIdTracking(Guid id, string includes);
        TEntity GetByIdTracking(Guid id);
        IQueryable<TEntity> List();
        IQueryable<TEntity> List(Expression<Func<TEntity, bool>> expression, string includes);
        IEnumerable<TEntity> Filtro(Expression<Func<TEntity, bool>> expression, Func<TEntity, object> orderBy, Boolean orderByDesc, out int totalRegistros, string includes, int offset = 1, int limit = 40);
        void Save(TEntity obj);
        void Save(IList<TEntity> obj);
        void Update(TEntity obj);
        void Delete(Guid id);

    }
}
