using System;
using System.Collections.Generic;
using IFExperiment.Domain.ExperimentContext.Entites;

namespace IFExperiment.Domain.ExperimentContext.Repositorio
{
    public interface IExperimentoRepository : IDisposable
    {
        IList<Experimento> GetByRange(int skip = 0, int take = 25);
        Experimento GetByIdAsNoTracking(Guid id);
        Experimento GetByIdTracking(Guid id);
        void Save(Experimento experimento);
        void Save(IList<Experimento> experimentos);
        void Update(Experimento experimento);
        void Delete(Guid id);
    }
}
