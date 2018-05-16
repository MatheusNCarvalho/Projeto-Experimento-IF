using System.Linq;
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
            var pTomate = new Planta(_tomate);
            var pCebola = new Planta(_cebola);
            var pCeneoura = new Planta(_cenoura);

            _experimento.AddPlanta(pTomate);
            _experimento.AddPlanta(pCeneoura);
            _experimento.AddPlanta(pCebola);
        }


        [TestMethod]
        public void DeveCriarUmExperimentoQuandoValido()
        {
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
            _experimento.GerarAreaExperimento();
            Assert.AreEqual(true, _experimento.AreaExperimentos.Any(item => item.Blocos.Count == 3));
            Assert.AreEqual(9, _experimento.AreaExperimentos.Sum(x => x.Blocos.Sum(x1 => x1.BlocoPlantas.Count)));

        }

        [TestMethod]
        public void DeveConter3BlocosCom9PlantasQuandoQtdRepeticaoFor10QuandoGerarAreaExperimento()
        {
            _experimento = new Experimento(_nome, 10);
            var pTomate = new Planta(_tomate);
            var pCebola = new Planta(_cebola);
            var pCeneoura = new Planta(_cenoura);

            _experimento.AddPlanta(pTomate);
            _experimento.AddPlanta(pCeneoura);
            _experimento.AddPlanta(pCebola);

            _experimento.GerarAreaExperimento();
            Assert.AreEqual(true, _experimento.AreaExperimentos.Any(item => item.Blocos.Count == 10));
            Assert.AreEqual(30, _experimento.AreaExperimentos.Sum(x => x.Blocos.Sum(x1 => x1.BlocoPlantas.Count)));

        }

    }
}
