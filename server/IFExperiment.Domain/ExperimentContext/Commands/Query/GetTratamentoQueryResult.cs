using System;
using IFExperiment.Shared.Commands;
using IFExperiment.Shared.Entities;
using IFExperiment.Shared.Enums;

namespace IFExperiment.Domain.ExperimentContext.Commands.Query
{
    public class GetTratamentoQueryResult : EntityResponse
    {
        public Guid Id { get;  set; }
        public string Nome { get;  set; }
        public ESimNao Excluido { get;  set; }

    }
}
