using System.Collections.Generic;
using System.Linq;
using IFExperiment.Shared.Entities;

namespace IFExperiment.Domain.ExperimentContext.Entites
{
    public class BlocoPlanta : EntityBase
    {
        private readonly IList<TipoAvaliacao> _tipoAvalicoes;

        public BlocoPlanta(string nome, Bloco bloco, Planta planta)
        {
            Nome = nome;
            Bloco = bloco;
            Planta = planta;
            _tipoAvalicoes = new List<TipoAvaliacao>();
        }

        public string Nome { get; protected set; }
        public Bloco Bloco { get; protected set; }
        public Planta Planta { get; protected set; }
        public IReadOnlyCollection<TipoAvaliacao> TipoAvaliacoes => _tipoAvalicoes.ToArray();

        public void AddTipoAvaliacao(TipoAvaliacao artefato)
        {
            _tipoAvalicoes.Add(artefato);
        }

        public void AddAllTipoAvalicao(List<TipoAvaliacao> tipoAvaliacaos)
        {
            foreach (var tipoAvaliacao in tipoAvaliacaos)
            {
                _tipoAvalicoes.Add(tipoAvaliacao);
            }
        }

        public void RemoveTipoAvaliacao(TipoAvaliacao artefato)
        {
            _tipoAvalicoes.Remove(artefato);
        }

    }
}
