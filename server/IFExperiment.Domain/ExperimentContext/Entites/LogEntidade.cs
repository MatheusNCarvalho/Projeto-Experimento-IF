using System;
using Dapper.Contrib.Extensions;
using IFExperiment.Domain.ExperimentContext.Enums;


namespace IFExperiment.Domain.ExperimentContext.Entites
{
    [Table("LogEntidades")]
    public class LogEntidade
    {
        protected LogEntidade() { }
        public LogEntidade(string entidadeAnterior, string entidadeNova, string usuario, string nomeClass, EAcao acao)
        {
            Id = Guid.NewGuid();
            DataCadastrado = DateTime.Now;
            EntidadeAnterior = entidadeAnterior;
            EntidadeNova = entidadeNova;
            Usuario = usuario;
            NomeClass = nomeClass;
            Acao = acao;
        }

        [ExplicitKey]
        public Guid Id { get; protected set; }
        public DateTime DataCadastrado { get; protected set; }
        public string EntidadeAnterior { get; protected set; }
        public string EntidadeNova { get; protected set; }
        public string Usuario { get; protected set; }
        public string NomeClass { get; protected set; }
        public EAcao Acao { get; protected set; }
    }
}
