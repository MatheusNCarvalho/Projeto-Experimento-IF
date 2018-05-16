namespace IFExperiment.Shared.Commands
{
    public interface ICommandResult
    {
        bool Sucesso { get; set; }
        string Messagem { get; set; }
        int Code { get; set; }
        object Data { get; set; }
    }
}
