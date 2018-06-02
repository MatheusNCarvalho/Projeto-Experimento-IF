using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using IFExperiment.Domain.ExperimentContext.Entites;
using IFExperiment.Domain.ExperimentContext.Enums;
using IFExperiment.Domain.ExperimentContext.Repositorio;
using IFExperiment.Infra.Contexts;

namespace IFExperiment.Infra.Repositorio
{
   public class ExperimentoRepository : IExperimentoRepository
   {

       private readonly AppDataContext _db;

       public ExperimentoRepository(AppDataContext db)
       {
           _db = db;
       }

        public void Dispose()
        {
            _db.Dispose();
        }

        public IList<Experimento> GetByRange(int skip = 0, int take = 25)
        {
            return _db.Experimentos.OrderBy(x => x.Nome).Skip(skip).Take(take).ToList();
        }

        public Experimento GetById(Guid id)
        {
            return _db.Experimentos.Find(id);
        }

        public void Save(Experimento experimento)
        {
            _db.Experimentos.Add(experimento);
            _db.SaveChanges();
        }

        public void Save(IList<Experimento> experimentos)
        {
            _db.Experimentos.AddRange(experimentos);
            _db.SaveChanges();
        }

        public void Update(Experimento experimento)
        {
            _db.Entry<Experimento>(experimento).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var experimento = GetById(id);
            experimento.AddExcluido(ESimNao.Sim);
            Update(experimento);
        }
    }
}
