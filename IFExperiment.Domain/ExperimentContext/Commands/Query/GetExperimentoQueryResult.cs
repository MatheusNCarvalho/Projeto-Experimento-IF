using System;
using IFExperiment.Shared.Commands;
using IFExperiment.Shared.Entities;

namespace IFExperiment.Domain.ExperimentContext.Commands.Query
{
    public class GetExperimentoQueryResult : EntityResponse
    {
        public Guid Id { get; set; }
        public string Nome { get;  set; }
        public string DataInicio { get;  set; }
        public int QtdRepeticao { get;  set; }
        public string Status { get;  set; }
    }
}
