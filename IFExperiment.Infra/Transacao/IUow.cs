namespace IFExperiment.Infra.Transacao
{
    public interface IUow
    {
        void Commit();
        void Rollback();
    }
}
