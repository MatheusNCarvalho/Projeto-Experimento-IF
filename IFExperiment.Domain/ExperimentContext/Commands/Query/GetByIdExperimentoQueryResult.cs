using System;
using System.Collections.Generic;
using IFExperiment.Domain.ExperimentContext.Enums;
using IFExperiment.Shared.Commands;

namespace IFExperiment.Domain.ExperimentContext.Commands.Query
{
    public class GetByIdExperimentoQueryResult : ICommandResult
    {

        public GetByIdExperimentoQueryResult()
        {
            ExperimentoTramentos = new List<GetTratamentoQueryResult>();
            Blocos = new List<BlocoQueryResult>();
        }
        public Guid Id { get; set; } 
        public string Nome { get;  set; }
        public string Codigo { get;  set; }
        public DateTime DataInicio { get;  set; }
        public DateTime DataConclusao { get;  set; }
        public int QtdRepeticao { get;  set; }
        public string Status { get;  set; }
        public IEnumerable<GetTratamentoQueryResult> ExperimentoTramentos { get; set ;}
        public IEnumerable<BlocoQueryResult> Blocos { get; set ;}
        
    }

    public class AreaExperimentoQueryResult : ICommandResult
    {
        public Guid Id { get; set; }
        public string Status { get;  set; }
    }

    public class BlocoQueryResult : ICommandResult
    {
        public Guid Id { get; set; }
        public string NomeBloco { get; set; }
    }
}
