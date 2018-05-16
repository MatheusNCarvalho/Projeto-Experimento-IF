using IFExperiment.Domain.ExperimentContext.Enums;

namespace IFExperiment.Domain.ExperimentContext.Entites
{
    public class TipoAvaliacao
    {

        public TipoAvaliacao(string valor, ETipoAvaliacao eTipoAvaliacao)
        {
            Valor = valor;
            ETipoAvaliacao = eTipoAvaliacao;
        }

        public string Valor { get; protected set; }
        public ETipoAvaliacao ETipoAvaliacao { get; protected set; }
    }
}