//using System.Collections.Generic;
//using System.Linq;
//using IFExperiment.Domain.ExperimentContext.Entites;
//using IFExperiment.Domain.ExperimentContext.Enums;
//using IFExperiment.Domain.ExperimentContext.ValueObjects;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace IFExperiment.Tests.Entities
//{

//    [TestClass]
//    public class AvaliacaoExperimentoTests
//    {

//        private AvaliacaoExperimento _avaliacaoExperimento;

//        [TestMethod]
//        public void CriandoAvaliacaoEGerarColetaDeAvaliacao()
//        {
//            var experimento = CriarExperimento();
//            var nome = "Avaliar Tamanho";
//            var eTipoAvaliacao = ETipoAvaliacao.Inteiro;

//            var nome2 = "Avaliar Qualidade";
//            var eTipoAvaliacao2 = ETipoAvaliacao.Audio;

//            var tipoAvaliacao = new TipoAvaliacao(nome, eTipoAvaliacao);
//            tipoAvaliacao.AddAvaliacaoExperimento(_avaliacaoExperimento);

//            var tipoAvaliacao2 = new TipoAvaliacao(nome2, eTipoAvaliacao2);
//            tipoAvaliacao2.AddAvaliacaoExperimento(_avaliacaoExperimento);

//            _avaliacaoExperimento = new AvaliacaoExperimento(experimento);

//            _avaliacaoExperimento.AddTipoAvaliacao(tipoAvaliacao);
//            _avaliacaoExperimento.AddTipoAvaliacao(tipoAvaliacao2);

//            _avaliacaoExperimento.Gerar();
//            Assert.AreEqual(true, _avaliacaoExperimento.Validated());
//            Assert.AreEqual(EAvaliacao.EmAdamento, _avaliacaoExperimento.Status);
//        }

//        [TestMethod]
//        public void RealizarAvaliacaoQuandoAvaliacaoEstiverCriada()
//        {
//            CriandoAvaliacaoEGerarColetaDeAvaliacao();

//            var tipoAvaliacao1 = (TipoAvaliacao)_avaliacaoExperimento.TipoAvaliacoes.ToArray().GetValue(0);
//            var tipoAvaliacao2 = (TipoAvaliacao)_avaliacaoExperimento.TipoAvaliacoes.ToArray().GetValue(1);

//            foreach (var bloco in _avaliacaoExperimento.Experimento.AreaExperimento.Blocos)
//            {
//                foreach (var blocoPlanta in bloco.BlocoTratamentos)
//                {
//                    tipoAvaliacao1.AddValor("Tamanho 1 cm");
//                    tipoAvaliacao2.AddValor("audioIdExperimentoDataHoraMinuto.mp3");

//                    List<TipoAvaliacao> avaliacoes = new List<TipoAvaliacao>();
//                    avaliacoes.Add(tipoAvaliacao1);
//                    avaliacoes.Add(tipoAvaliacao2);
//                    //_avaliacaoExperimento.RealizarAvalicao(bloco, blocoTratamento, avaliacoes);
//                }
//            }
//            Assert.AreEqual(true, _avaliacaoExperimento.Validated());
//        }


//        [TestMethod]
//        public void ArquivarQuandoSalvarAvaliacao()
//        {
//            _avaliacaoExperimento.Arqivar();
//        }

//        [TestMethod]
//        public void ArquivarQuandoAvaliacaoEstiverEmAndamento()
//        {
//            _avaliacaoExperimento.ArqivarAvaliacaoEAdamento();
//        }

//        protected Experimento CriarExperimento()
//        {
//            var nome = new Nome("Experimento tomate");
//            var tomate = new Nome("tomate");
//            var cebola = new Nome("cebola");
//            var cenoura = new Nome("ceneroura");

//            var experimento = new Experimento(nome, 3);
//            var pTomate = new Tratamento(tomate);
//            var pCebola = new Tratamento(cebola);
//            var pCeneoura = new Tratamento(cenoura);

//            var experimentoPlantaTomante = new ExperimentoTramento(experimento, pTomate);
//            var experimentoPlantaCeneoura = new ExperimentoTramento(experimento, pCeneoura);
//            var experimentoPlantaCebola = new ExperimentoTramento(experimento, pCebola);

//            experimento.AddTratamento(experimentoPlantaTomante);
//            experimento.AddTratamento(experimentoPlantaCeneoura);
//            experimento.AddTratamento(experimentoPlantaCebola);
//            experimento.Gerar();
//            return experimento;
//        }
//    }
//}
