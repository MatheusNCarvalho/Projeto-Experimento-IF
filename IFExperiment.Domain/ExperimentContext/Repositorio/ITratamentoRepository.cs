using System;
using System.Collections.Generic;
using IFExperiment.Domain.ExperimentContext.Entites;

namespace IFExperiment.Domain.ExperimentContext.Repositorio
{
    public interface ITratamentoRepository : IDisposable
    {
        IList<Tratamento> GetByRange(int skip = 0, int take = 25);
        Tratamento GetById(Guid id);
        void Save(Tratamento experimento);
        void Save(IList<Tratamento> experimentos);
        void Update(Tratamento experimento);
        void Delete(Guid id);
    }
}
