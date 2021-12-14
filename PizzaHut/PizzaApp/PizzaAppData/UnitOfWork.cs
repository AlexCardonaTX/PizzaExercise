namespace PizzaHut.PizzaApp.Data
{
    public class UnitOfWork
    {
        private readonly PizzaAppDBContext _pizzaAppDBContext;
        public UnitOfWork(PizzaAppDBContext pizzaAppDBContext)
        {
            _pizzaAppDBContext = pizzaAppDBContext;
        }

        public void BeginTransaction()
        {
            _pizzaAppDBContext.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _pizzaAppDBContext.Database.CommitTransaction();
        }

        public void RollBackTransaction()
        {
            _pizzaAppDBContext.Database.RollbackTransaction();
        }

        public void Save()
        {
            BeginTransaction();
            _pizzaAppDBContext.SaveChanges();
            CommitTransaction();
        }
    }
}
