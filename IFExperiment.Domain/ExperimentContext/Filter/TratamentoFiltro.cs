using System;
using System.Linq.Expressions;
using IFExperiment.Domain.ExperimentContext.Entites;
using IFExperiment.Shared.Enums;
using LinqKit;

namespace IFExperiment.Domain.ExperimentContext.Filter
{
    public class TratamentoFiltro : BaseFiltro<Tratamento>
    {
        public string Nome { get;  set; }
        public string DataInicio { get;  set; }
        public string DataFim { get;  set; }

        public override Expression<Func<Tratamento, bool>> MountExpression()
        {
            Expression<Func<Tratamento, bool>> expression = c => true;

            expression = expression.And(x => x.Excluido == ESimNao.Nao);

            if (!string.IsNullOrEmpty(Nome))
                expression = expression.And(x => x.Nome.Valor == Nome);

            if (DataInicio != null && DataFim != null)
            {
               // expression = expression.And(x => x.DataCadastrado >= DataInicio && x.DataCadastrado <= DataFim);
            }

            return expression;
        }
    }
}
