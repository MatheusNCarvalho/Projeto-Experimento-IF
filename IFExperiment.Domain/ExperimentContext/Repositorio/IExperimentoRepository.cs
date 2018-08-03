using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using IFExperiment.Domain.ExperimentContext.Commands.Query;
using IFExperiment.Domain.ExperimentContext.Entites;

namespace IFExperiment.Domain.ExperimentContext.Repositorio
{
    public interface IExperimentoRepository : IRepositorio<Experimento>
    {
        IList<GetExperimentoQueryResult> GetByRange(Expression<Func<Experimento, bool>> expression, Func<Experimento, object> orderBy, Boolean orderByDesc, int page = 1, int itemPerPage = 10);
        GetByIdExperimentoQueryResult GetByIdAsNoTracking(Guid id);
    }
}
