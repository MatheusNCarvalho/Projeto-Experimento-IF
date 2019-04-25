using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Dapper;
using IFExperiment.Domain.ExperimentContext.Entites;
using IFExperiment.Domain.ExperimentContext.Enums;
using IFExperiment.Domain.ExperimentContext.Repositorio;
using IFExperiment.Infra.Contexts;
using IFExperiment.Shared;
using IFExperiment.Shared.Entities;
using IFExperiment.Shared.Util;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace IFExperiment.Infra.Repositorio
{
    public abstract class Repositorio<TEntity, TResponse> : IRepositorio<TEntity, TResponse>
        where TEntity : EntityBase
        where TResponse : EntityResponse
    {

        private readonly AppDataContext _db;

        // private readonly ILogEntidadeRepositorio _logEntidadeRepositorio;

        protected Repositorio(AppDataContext db)
        {
            _db = db;
            // _logEntidadeRepositorio = new LogEntidadeRepositorio(db);
        }

        public void Dispose()
        {
            _db?.Dispose();
        }

        public TEntity GetByIdTracking(Guid id, string includes)
        {
            var db = _db.Set<TEntity>().AsQueryable();

            string[] includeArray = includes.Split(',');

            if (includeArray.Any())
            {
                foreach (var include in includeArray)
                {
                    db = db.Include(include);
                }
            }

            return db
                .AsExpandable()
                .FirstOrDefault(x => x.Id == id);
        }

        public TEntity GetByIdTracking(Guid id)
        {
            return _db.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> List()
        {
            return _db.Set<TEntity>()
                .AsQueryable()
                .AsNoTracking();
        }

        public IQueryable<TEntity> List(Expression<Func<TEntity, bool>> expression, string includes)
        {
            var contexto = _db.Set<TEntity>().AsQueryable();

            string[] includeArray = includes.Split(',');

            if (includeArray.Any())
            {
                foreach (var include in includeArray)
                {
                    contexto = contexto.Include(include);
                }
            }

            return contexto
                .AsExpandable()
                .Where(expression)
                .AsQueryable()
                .AsNoTracking();
        }

        public IEnumerable<TEntity> Filtro(Expression<Func<TEntity, bool>> expression, Func<TEntity, object> orderBy, bool orderByDesc, out int totalRegistros, string includes,
            int offset = 1, int limit = 40)
        {
            var contexto = _db.Set<TEntity>().AsQueryable();

            totalRegistros = contexto.Where(expression).Count();


            //Adiciona as propriedades a serem carregadas
            if (!string.IsNullOrWhiteSpace(includes))
            {
                string[] incluideArray = includes.Split(',');

                foreach (var include in incluideArray)
                {
                    contexto = contexto.Include(include);
                }
            }

            if (orderByDesc)
            {
                var results = contexto
                    .Where(expression)
                    .AsEnumerable()
                    .OrderBy(orderBy)
                    .Skip(offset)
                    .Take(limit)
                    .AsQueryable()
                    .AsNoTracking()
                    .ToList();
                return results;
            }
            else
            {
                var results = contexto
                    .Where(expression)
                    .AsEnumerable()
                    .OrderByDescending(orderBy)
                    .Skip(offset)
                    .Take(limit)
                    .AsQueryable()
                    .AsNoTracking()
                    .ToList();
                return results;
            }
        }

        public void Save(TEntity obj)
        {
            _db.Set<TEntity>().Add(obj);

            // GravaLog(new LogEntidade(null, ConverterJson.ObjetoParaJson(obj), null, typeof(T).Name, EAcao.Inserido));
        }

        public void Save(IList<TEntity> obj)
        {
            _db.Set<TEntity>().AddRange(obj);

            foreach (var o in obj)
            {
                GravaLog(new LogEntidade(null, ConverterJson.ObjetoParaJson(o), null, typeof(TEntity).Name, EAcao.Inserido));
            }
        }

        public void Update(TEntity obj)
        {
            //GravaLog(new LogEntidade(ConverterJson.ObjetoParaJson(GetByIdTracking(obj.Id)), ConverterJson.ObjetoParaJson(obj), null, typeof(T).Name, EAcao.Atualizado));
            _db.Entry(obj).State = EntityState.Detached;
            _db.Entry(obj).State = EntityState.Modified;


        }

        public void Delete(Guid id)
        {
            var obj = GetByIdTracking(id);
            obj.AddExcluido();
            obj.AddDataExclusao();
            Update(obj);

            //GravaLog(new LogEntidade(ConverterJson.ObjetoParaJson(GetByIdTracking(obj.Id)), null, null, typeof(T).Name, EAcao.Deletado));
        }

        public void GravaLog(LogEntidade log)
        {
            using (var conn = new NpgsqlConnection(Settings.ConnectionStringHomologacao))
            {
                conn.Open();

                //    INSERT INTO public."LogEntidades"(
                //"Id", "DataCadastrado", "DataAlteracao", "DataExclusao", "Excluido", "EntidadeAnterior", "EntidadeNova", "Usuario", "NomeClass", "Acao")
                //VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?);

                conn.Execute("INSERT INTO public.LogEntidades(Id,DataCadastrado,EntidadeAnterior, EntidadeNova, Usuario, NomeClass, Acao) " +
                                     " VALUES " +
                                     "(@Id,@DataCadastrado,@EntidadeAnterior, @EntidadeNova, @Usuario, @NomeClass, @Acao)", log);
                //conn.Insert(log);
                conn.Close();
            }
        }
    }
}
