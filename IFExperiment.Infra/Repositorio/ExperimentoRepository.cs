using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HibernatingRhinos.Profiler.Appender.EntityFramework;
using IFExperiment.Domain.ExperimentContext.Commands.Query;
using IFExperiment.Domain.ExperimentContext.Entites;
using IFExperiment.Domain.ExperimentContext.Repositorio;
using IFExperiment.Infra.Contexts;
using IFExperiment.Shared.Enums;
using Microsoft.EntityFrameworkCore;

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
                            Name = tramento.Tratamento.Nome.ToString(),
                            Excluido = tramento.Tratamento.Excluido
                        }),
                    Blocos = x.Blocos.Select(bloco => new BlocoQueryResult
                    {
                        Id = bloco.Id,
                        NomeBloco = bloco.NomeBloco
                    })

                })
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
        }


        public List<GetTratamentoQueryResult> teste(IEnumerable<ExperimentoTramento> list)
        {
            IList<GetTratamentoQueryResult> listaTratamento = new List<GetTratamentoQueryResult>();

            foreach (var experimentoTramento in list)
            {
                listaTratamento.Add(new GetTratamentoQueryResult
                {
                    Id = experimentoTramento.TratamentoId,
                    Name = experimentoTramento.Tratamento.Nome.ToString(),
                    Excluido = experimentoTramento.Tratamento.Excluido
                });
            }

            return (List<GetTratamentoQueryResult>)listaTratamento;
        }

        public Experimento GetByIdTracking(Guid id)
        {

            return _db.Experimentos.Find(id);

        }



        public void Save(Experimento experimento)
        {
            _db.Experimentos.Add(experimento);

        }

        public void Save(IList<Experimento> experimentos)
        {
            _db.Experimentos.AddRange(experimentos);

        }

        public void Update(Experimento experimento)
        {
            experimento.AddDataAlteracao(DateTime.Now);
            _db.Entry(experimento).State = EntityState.Modified;

        }

        public void Delete(Guid id)
        {
            var experimento = GetByIdTracking(id);
            experimento.AddDataExclusao(DateTime.Now);
            experimento.AddExcluido(ESimNao.Sim);
            Update(experimento);
        }

        public static void GravaLog(string sql)
        {
            Console.WriteLine("Comando SQL: " + sql);
            Console.ReadLine();
        }
    }
}
