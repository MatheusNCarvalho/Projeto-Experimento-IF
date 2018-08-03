using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using IFExperiment.Domain.ExperimentContext.Commands.Query;
using IFExperiment.Domain.ExperimentContext.Entites;
using IFExperiment.Domain.ExperimentContext.Repositorio;
using IFExperiment.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace IFExperiment.Infra.Repositorio
{
    public class ExperimentoRepository : Repositorio<Experimento>, IExperimentoRepository
    {

        private readonly AppDataContext _db;

        public ExperimentoRepository(AppDataContext db) : base(db)
        {
            _db = db;
        }

        public IList<GetExperimentoQueryResult> GetByRange(Expression<Func<Experimento, bool>> expression, Func<Experimento, object> orderBy, Boolean orderByDesc, int page = 1, int itemPerPage = 10)
        {
            //AsNoTracking para não trazer o proxy na consulta
            if (orderByDesc)
            {
                var result = _db.Experimentos
                    .Where(expression).OrderByDescending(orderBy)
                    .Skip((page - 1) * itemPerPage)
                    .Take(itemPerPage).AsQueryable()
                    .Select(x => new GetExperimentoQueryResult()
                    {
                        Id = x.Id,
                        Nome = x.Nome.ToString(),
                        DataInicio = x.DataInicio.ToString("MM/dd/yyyy"),
                        QtdRepeticao = x.QtdRepeticao,
                        Status = x.Status.ToString()

                    })
                    .AsNoTracking()
                    .ToList();
                return result;
            }
            else
            {
                var result = _db.Experimentos
                    .Where(expression).OrderBy(orderBy)
                    .Skip((page - 1) * itemPerPage)
                    .Take(itemPerPage).AsQueryable()
                    .Select(x => new GetExperimentoQueryResult()
                    {
                        Id = x.Id,
                        Nome = x.Nome.ToString(),
                        DataInicio = x.DataInicio.ToString("MM/dd/yyyy"),
                        QtdRepeticao = x.QtdRepeticao,
                        Status = x.Status.ToString()

                    })
                    .AsNoTracking()
                    .ToList();
                return result;
            }
        }

        public GetByIdExperimentoQueryResult GetByIdAsNoTracking(Guid id)
        {
            //Find() ainda não suporte AsNoTracking
            //FirstOrDefault pegar o primeiro item que encontrar
            return _db.Experimentos
                .Select(x => new GetByIdExperimentoQueryResult
                {
                    Id = x.Id,
                    Nome = x.Nome.ToString(),
                    Codigo = x.Codigo,
                    DataInicio = x.DataInicio,
                    DataConclusao = x.DataConclusao,
                    QtdRepeticao = x.QtdRepeticao,
                    Status = x.Status.ToString(),
                    ExperimentoTramentos = x.ExperimentoTramentos
                        .Select(tramento => new GetTratamentoQueryResult
                        {
                            Id = tramento.TratamentoId,
                            Nome = tramento.Tratamento.Nome.ToString(),
                            Excluido = tramento.Tratamento.Excluido
                        }),
                    Blocos = x.Blocos.Select(bloco => new BlocoQueryResult
                    {
                        Id = bloco.Id,
                        NomeBloco = bloco.NomeBloco,
                        BlocoTratamentoQueryResults = bloco.BlocoTratamentos.Select(blocoTratamento => new BlocoTratamentoQueryResult
                        {
                            NomeParcela = blocoTratamento.NomeParcela,
                            NomeTratamento = blocoTratamento.Tratamento.Nome.ToString()
                        })
                    })

                })
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
        }


    }
}
