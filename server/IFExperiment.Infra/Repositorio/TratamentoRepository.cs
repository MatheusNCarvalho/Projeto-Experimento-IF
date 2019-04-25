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
    public class TratamentoRepository :Repositorio<Tratamento, GetTratamentoQueryResult>, ITratamentoRepository
    {
        private readonly AppDataContext _db;


        public TratamentoRepository(AppDataContext db) : base(db)
        {
            _db = db;
        }

        public IList<GetTratamentoQueryResult> GetByRange(Expression<Func<Tratamento, bool>> expression, Func<Tratamento, object> orderBy, Boolean orderByDesc, int page = 1, int itemPerPage = 10)
        {
            //AsNoTracking para não trazer o proxy na consulta
            if (orderByDesc)
            {
                var result = _db.Tratamentos
                    .Where(expression).OrderBy(orderBy)
                    .Skip((page - 1) * itemPerPage)
                    .Take(itemPerPage).AsQueryable()
                    .Select(x => new GetTratamentoQueryResult
                    {
                        Id = x.Id,
                        Nome = x.Nome.ToString(),
                        Excluido = x.Excluido
                    })
                    .AsNoTracking()
                    .ToList();
                return result;
            }
            else
            {
                var result = _db.Tratamentos
                    .Where(expression).OrderByDescending(orderBy)
                    .Skip((page - 1) * itemPerPage)
                    .Take(itemPerPage).AsQueryable()
                    .Select(x => new GetTratamentoQueryResult
                    {
                        Id = x.Id,
                        Nome = x.Nome.ToString(),
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
                Nome = x.Nome.ToString(),
                Excluido = x.Excluido
            }).AsNoTracking().FirstOrDefault(x => x.Id == id && x.Excluido == ESimNao.Nao);
        }
    }
}
