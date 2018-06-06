using System;
using IFExperiment.Domain.ExperimentContext.Enums;

namespace IFExperiment.Domain.ExperimentContext.Queries
{
    public class GetTratamentoQueryResult
    {
        public GetTratamentoQueryResult(Guid id, string name, EStatus status)
        {
            Id = id;
            Name = name;
            Status = status;
        }

        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public EStatus Status { get; protected set; }

    }
}
