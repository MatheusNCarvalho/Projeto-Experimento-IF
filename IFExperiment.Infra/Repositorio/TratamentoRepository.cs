using System;
using System.Collections.Generic;
using System.Linq;
using IFExperiment.Domain.ExperimentContext.Entites;
using IFExperiment.Domain.ExperimentContext.Repositorio;
using IFExperiment.Infra.Contexts;
using IFExperiment.Shared.Enums;
using Microsoft.EntityFrameworkCore;

namespace IFExperiment.Infra.Repositorio
{
    public class TratamentoRepository : ITratamentoRepository
    {
        private readonly AppDataContext _db;

        public TratamentoRepository(AppDataContext db)
        {
            _db = db;
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public IList<Tratamento> GetByRange(int skip = 0, int take = 25)
        {
            //AsNoTracking para não trazer o proxy na consulta
            return _db.Tratamentos.OrderBy(x => x.Nome).Skip(skip).Take(take).AsNoTracking().ToList();
        }

        public Tratamento GetByIdAsNoTracking(Guid id)
        {
            return _db.Tratamentos.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public Tratamento GetByIdTracking(Guid id)
        {
            return _db.Tratamentos.Find(id);
        }

       

        public void Save(Tratamento tratamento)
        {
            _db.Tratamentos.Add(tratamento);
            _db.SaveChanges();
        }

        public void Save(IList<Tratamento> experimentos)
        {
            _db.Tratamentos.AddRange(experimentos);
            _db.SaveChanges();
        }

        public void Update(Tratamento experimento)
        {
            _db.Entry(experimento).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var tratamento = GetById(id);
            tratamento.AddExcluido(ESimNao.Sim);
            Update(tratamento);
        }
    }
}
