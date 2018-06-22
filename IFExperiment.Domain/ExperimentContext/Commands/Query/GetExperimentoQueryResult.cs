using System;
using IFExperiment.Shared.Commands;

namespace IFExperiment.Domain.ExperimentContext.Commands.Query
{
    public class GetExperimentoQueryResult : ICommandResult
    {
        public Guid Id { get; set; }
        public string Nome { get;  set; }
        public string DataInicio { get;  set; }
        public int QtdRepeticao { get;  set; }
        public string Status { get;  set; }
    }
}
