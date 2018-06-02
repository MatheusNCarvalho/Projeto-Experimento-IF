using IFExperiment.Shared.Commands;

namespace IFExperiment.Domain.ExperimentContext.Commands.Outputs
{
    public class CommandResult : ICommandResult
    {
        public CommandResult(bool sucesso, string messagem, int code, object data)
        {
            Sucesso = sucesso;
            Messagem = messagem;
            Code = code;
            Data = data;
        }

        public CommandResult(object data)
        {
            Sucesso = false;
            Messagem = "Ocorreu um erro interno";
            Data = data;
            Code = 400;
        }

        public bool Sucesso { get; set; }
        public string Messagem { get; set; }
        public int Code { get; set; }
        public object Data { get; set; }
    }
}
