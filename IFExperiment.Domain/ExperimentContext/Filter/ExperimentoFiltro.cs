using System;
using System.Linq.Expressions;
using IFExperiment.Domain.ExperimentContext.Entites;

namespace IFExperiment.Domain.ExperimentContext.Filter
{
    public class ExperimentoFiltro : BaseFiltro<Experimento>
    {
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int Status { get; set; }

        public override Expression<Func<Experimento, bool>> MountExpression()
        {
            Expression<Func<Experimento, bool>> expression = c => true;

            return expression;
        }
    }
}
