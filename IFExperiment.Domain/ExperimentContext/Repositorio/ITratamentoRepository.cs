using System;
using IFExperiment.Domain.ExperimentContext.Commands.Query;
using IFExperiment.Domain.ExperimentContext.Entites;

namespace IFExperiment.Domain.ExperimentContext.Repositorio
{
    public interface ITratamentoRepository : IRepositorio<Tratamento, GetTratamentoQueryResult>
    {
        GetTratamentoQueryResult GetByIdAsNoTracking(Guid id);
    }
}
