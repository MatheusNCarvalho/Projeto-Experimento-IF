using System;
using IFExperiment.Shared.Commands;
using IFExperiment.Shared.Enums;

namespace IFExperiment.Domain.ExperimentContext.Commands.Query
{
    public class GetTratamentoQueryResult : ICommandResult
    {
        public Guid Id { get;  set; }
        public string Name { get;  set; }
        public ESimNao Excluido { get;  set; }

    }
}
