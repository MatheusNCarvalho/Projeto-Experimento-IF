using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using IFExperiment.Domain.ExperimentContext.Commands.Query;
using IFExperiment.Domain.ExperimentContext.Entites;

namespace IFExperiment.Domain.ExperimentContext.Repositorio
{
    public interface ITratamentoRepository : IRepositorio<Tratamento>
    {
        IList<GetTratamentoQueryResult> GetByRange(Expression<Func<Tratamento, bool>> expression, Func<Tratamento, object> orderBy, Boolean orderByDesc, int page = 1, int itemPerPage = 10);
        GetTratamentoQueryResult GetByIdAsNoTracking(Guid id);
    }
}
