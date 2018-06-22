using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using IFExperiment.Domain.ExperimentContext.Commands.Query;
using IFExperiment.Domain.ExperimentContext.Entites;

namespace IFExperiment.Domain.ExperimentContext.Repositorio
{
    public interface IExperimentoRepository : IDisposable
    {
        IList<GetExperimentoQueryResult> GetByRange(Expression<Func<Experimento, bool>> expression, Func<Experimento, object> orderBy, Boolean orderByDesc, int page = 1, int itemPerPage = 10);
        GetByIdExperimentoQueryResult GetByIdAsNoTracking(Guid id);
        Experimento GetByIdTracking(Guid id);
        void Save(Experimento experimento);
        void Save(IList<Experimento> experimentos);
        void Update(Experimento experimento);
        void Delete(Guid id);
    }
}
