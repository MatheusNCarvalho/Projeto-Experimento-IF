using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using IFExperiment.Domain.ExperimentContext.Commands.Query;
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

        public IList<GetTratamentoQueryResult> GetByRange(Expression<Func<Tratamento, bool>> expression, Func<Tratamento, object> orderBy, Boolean orderByDesc, int page = 1, int itemPerPage = 10)
        {
            //AsNoTracking para não trazer o proxy na consulta
            if (orderByDesc)
            {
                var result = _db.Tratamentos
                    .Where(expression).OrderByDescending(orderBy)
                    .Skip((page - 1) * itemPerPage)
                    .Take(itemPerPage).AsQueryable()
                    .Select(x => new GetTratamentoQueryResult
                    {
                        Id = x.Id,
                        Name = x.Nome.ToString(),
                        Excluido = x.Excluido
                    })
                    .AsNoTracking()
                    .ToList();
                return result;
            }
            else
            {
                var result = _db.Tratamentos
                    .Where(expression).OrderBy(orderBy)
                    .Skip((page - 1) * itemPerPage)
                    .Take(itemPerPage).AsQueryable()
                    .Select(x => new GetTratamentoQueryResult
                    {
                        Id = x.Id,
                        Name = x.Nome.ToString(),
                        Excluido = x.Excluido
                    })
                    .AsNoTracking()
                    .ToList();
                return result;
            }
        }

        public GetTratamentoQueryResult GetByIdAsNoTracking(Guid id)
        {
            return _db.Tratamentos.Select(x => new GetTratamentoQueryResult
            {
                Id = x.Id,
                Name = x.Nome.ToString(),
                Excluido = x.Excluido
            }).AsNoTracking().FirstOrDefault(x => x.Id == id && x.Excluido == ESimNao.Nao);
        }

        public Tratamento GetByIdTracking(Guid id)
        {
            var tratamento = _db.Tratamentos.Find(id);
            if (tratamento.Excluido.Equals(ESimNao.Nao))
                return tratamento;
            return null;
        }

        public void Save(Tratamento tratamento)
        {
            _db.Tratamentos.Add(tratamento);

        }

        public void Save(IList<Tratamento> experimentos)
        {
            _db.Tratamentos.AddRange(experimentos);

        }

        public void Update(Tratamento experimento)
        {
            experimento.AddDataAlteracao(DateTime.Now);
            _db.Entry(experimento).State = EntityState.Modified;

        }

        public void Delete(Guid id)
        {
            var tratamento = GetByIdTracking(id);
            tratamento.Inativo();
            tratamento.AddExcluido(ESimNao.Sim);
            tratamento.AddDataExclusao(DateTime.Now);
            Update(tratamento);
        }
    }
}
