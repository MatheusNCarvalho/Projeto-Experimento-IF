using IFExperiment.Infra.Contexts;

namespace IFExperiment.Infra.Transacao
{
    public class Uow : IUow
    {
        private readonly AppDataContext _db;

        public Uow(AppDataContext db)
        {
            _db = db;
        }

        public void Commit()
        {
            _db.SaveChanges();
        }

        public void Rollback()
        {
           //Não fazer anda
        }
    }
}
