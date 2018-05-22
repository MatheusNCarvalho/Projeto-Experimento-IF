using System;
using IFExperiment.Domain.ExperimentContext.Enums;
using IFExperiment.Shared.Entities;

namespace IFExperiment.Domain.ExperimentContext.Entites
{
    public class TipoAvaliacao : EntityBase
    {

        public TipoAvaliacao(string nome, ETipoAvaliacao eTipoAvaliacao)
        {

            Nome = nome;
            ETipoAvaliacao = eTipoAvaliacao;
        }


        public string Nome { get; protected set; }
        public string Valor { get; protected set; }
        public ETipoAvaliacao ETipoAvaliacao { get; protected set; }

        public Guid AvaliacaoExperimentoID { get; protected set; }
        public Guid PlantaId { get; protected set; }
        public AvaliacaoExperimento AvaliacaoExperimento { get; protected set; }
        public Planta Planta { get; protected set; }


        public void AddPlanta(Planta planta)
        {
            Planta = planta;
        }

        public void AddAvaliacaoExperimento(AvaliacaoExperimento avaliacaoExperimento)
        {
            AvaliacaoExperimento = avaliacaoExperimento;
        }


        public void AddValor(string valor)
        {
            Valor = valor;
        }

    }
}