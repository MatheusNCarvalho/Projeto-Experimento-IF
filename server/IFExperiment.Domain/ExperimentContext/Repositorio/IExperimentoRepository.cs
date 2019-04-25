using System;
using IFExperiment.Domain.ExperimentContext.Commands.Query;
using IFExperiment.Domain.ExperimentContext.Entites;

namespace IFExperiment.Domain.ExperimentContext.Repositorio
{
    public interface IExperimentoRepository : IRepositorio<Experimento, GetTratamentoQueryResult>
    {
        GetByIdExperimentoQueryResult GetByIdAsNoTracking(Guid id);
    }
}
