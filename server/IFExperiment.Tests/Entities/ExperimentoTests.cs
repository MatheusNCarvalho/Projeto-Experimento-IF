﻿using System.Linq;
using IFExperiment.Domain.ExperimentContext.Entites;
using IFExperiment.Domain.ExperimentContext.Enums;
using IFExperiment.Domain.ExperimentContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IFExperiment.Tests.Entities
{
    [TestClass]
    public class ExperimentoTests
    {
        

        private Experimento _experimento;
        private readonly Nome _nome;
        private readonly Nome _tomate;
        private readonly Nome _cebola;
        private readonly Nome _cenoura;
        
        public ExperimentoTests()
        {
            _nome = new Nome("Experimento tomate");
            _tomate = new Nome("tomate");
            _cebola = new Nome("cebola");
            _cenoura = new Nome("ceneroura");

            _experimento = new Experimento(_nome, 3);
            var pTomate = new Tratamento(_tomate);
            var pCebola = new Tratamento(_cebola);
            var pCeneoura = new Tratamento(_cenoura);

            var experimentoPlantaTomante = new ExperimentoTramento(_experimento.Id, pTomate.Id);
            var experimentoPlantaCeneoura = new ExperimentoTramento(_experimento.Id, pCeneoura.Id);
            var experimentoPlantaCebola = new ExperimentoTramento(_experimento.Id, pCebola.Id);

    
            _experimento.AddTratamento(experimentoPlantaTomante);
            _experimento.AddTratamento(experimentoPlantaCeneoura);
            _experimento.AddTratamento(experimentoPlantaCebola);
        }


        [TestMethod]
        public void DeveCriarUmExperimentoQuandoValido()
        {
            _experimento.Gerar();
            Assert.AreEqual(true, _experimento.Validated());
        
        }

        [TestMethod]
        public void StatusAbertoDeveSerQuandoExperimentoForCriado()
        {
            Assert.AreEqual(EExperimentoStatus.Aberto, _experimento.Status);
        }

        [TestMethod]
        public void DeveConter3BlocosCom9PlantasQuandoQtdRepeticaoFor3QuandoGerarAreaExperimento()
        {
            
            Assert.AreEqual(true, _experimento.Blocos.Count == 3);
            Assert.AreEqual(9, _experimento.Blocos.Sum((x1 => x1.BlocoTratamentos.Count)));

        }

        [TestMethod]
        public void DeveConter3BlocosCom9PlantasQuandoQtdRepeticaoFor10QuandoGerarAreaExperimento()
        {
            _experimento = new Experimento(_nome, 10);
            var pTomate = new Tratamento(_tomate);
            var pCebola = new Tratamento(_cebola);
            var pCeneoura = new Tratamento(_cenoura);

            var experimentoPlantaTomante = new ExperimentoTramento(_experimento.Id, pTomate.Id);
            var experimentoPlantaCeneoura = new ExperimentoTramento(_experimento.Id, pCeneoura.Id);
            var experimentoPlantaCebola = new ExperimentoTramento(_experimento.Id, pCebola.Id);

            _experimento.AddTratamento(experimentoPlantaTomante);
            _experimento.AddTratamento(experimentoPlantaCeneoura);
            _experimento.AddTratamento(experimentoPlantaCebola);

            _experimento.GerarAreaExperimento();
            Assert.AreEqual(true, _experimento.Blocos.Count == 10);
            Assert.AreEqual(30, _experimento.Blocos.Sum((x1 => x1.BlocoTratamentos.Count)));

        }

    }
}
