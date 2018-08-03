using System;
using System.Collections.Generic;
using System.Linq;
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
    public abstract class Repositorio<T> : IRepositorio<T> where T : EntityBase
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

        public T GetByIdTracking(Guid id, string[] includes = null)
        {
            var db = _db.Set<T>().AsQueryable();

            if (includes != null && includes.Any())
            {
                foreach (var include in includes)
                {
                    db = db.Include(include);
                }
            }

            return db
                .AsExpandable()
                .FirstOrDefault(x => x.Id == id);
        }

        public T GetByIdTracking(Guid id)
        {
            return _db.Set<T>().Find(id);
        }

        public void Save(T obj)
        {
            _db.Set<T>().Add(obj);

           // GravaLog(new LogEntidade(null, ConverterJson.ObjetoParaJson(obj), null, typeof(T).Name, EAcao.Inserido));
        }

        public void Save(IList<T> obj)
        {
            _db.Set<T>().AddRange(obj);

            foreach (var o in obj)
            {
                GravaLog(new LogEntidade(null, ConverterJson.ObjetoParaJson(o), null, typeof(T).Name, EAcao.Inserido));
            }
        }

        public void Update(T obj)
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
