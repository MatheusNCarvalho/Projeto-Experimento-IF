﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using IFExperiment.Domain.ExperimentContext.Enums;
//using IFExperiment.Shared.Entities;

//namespace IFExperiment.Domain.ExperimentContext.Entites
//{
//    public class AvaliacaoExperimento : EntityBase
//    {
//        private readonly IList<TipoAvaliacao> _tipoAvaliacoes;

//        public AvaliacaoExperimento(Experimento experimento)
//        {
//            DataAvalicao = DateTime.Now;
//            Experimento = experimento;
//            _tipoAvaliacoes = new List<TipoAvaliacao>();

//        }


//        public DateTime DataAvalicao { get; protected set; }
//        public Experimento Experimento { get; protected set; }
//        public EAvaliacao Status { get; protected set; }
//        public DateTime DataConclusao { get;  protected set; }
//        public IReadOnlyCollection<TipoAvaliacao> TipoAvaliacoes => _tipoAvaliacoes.ToArray();
//        public IReadOnlyCollection<ColetaExperimento> ColetaExperimentos { get; set; }


//        public void Gerar()
//        {
//            Status = EAvaliacao.EmAdamento;
//        }

//        public void Arqivar()
//        {
//            Status = EAvaliacao.Aberto;
//        }

//        public void ArqivarAvaliacaoEAdamento()
//        {
//            Status = EAvaliacao.EmAdamento;
//        }
//        public void Concluir()
//        {
//            Status = EAvaliacao.Concluido;
//            DataConclusao = DateTime.Now;
//        }

//        public void AddTipoAvaliacao(TipoAvaliacao tipoAvaliacao)
//        {
//            _tipoAvaliacoes.Add(tipoAvaliacao);
//        }

//        public void RangeTipoAvaliacao(List<TipoAvaliacao> tipoAvaliacao)
//        {
//            foreach (var avaliacao in tipoAvaliacao)
//            {
//                _tipoAvaliacoes.Add(avaliacao);
//            }
//        }

//        public void RemoveTipoAvaliacao(TipoAvaliacao tipoAvaliacao)
//        {
//            _tipoAvaliacoes.Remove(tipoAvaliacao);
//        }

//        public override bool Validated()
//        {
//           AddNotifications(Experimento.Notifications);
//           foreach (var tipoAvaliacao in TipoAvaliacoes)
//           {
//               AddNotifications(tipoAvaliacao.Notifications);
//           }

//            return base.Validated();
//        }
//    }
//}
