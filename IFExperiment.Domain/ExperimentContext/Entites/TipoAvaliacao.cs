using IFExperiment.Domain.ExperimentContext.Enums;

namespace IFExperiment.Domain.ExperimentContext.Entites
{
    public class TipoAvaliacao
    {

        public TipoAvaliacao(string chave, string valor, ETipoAvaliacao eTipoAvaliacao)
        {
            Valor = valor;
            Chave = chave;
            ETipoAvaliacao = eTipoAvaliacao;
        }


        public string Chave { get; protected set; }
        public string Valor { get; protected set; }
        public ETipoAvaliacao ETipoAvaliacao { get; protected set; }
    }
}