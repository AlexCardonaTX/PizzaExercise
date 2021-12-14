using PizzaHut.PizzaApp.Data.Repositories;
using PizzaHut.PizzaApp.Data.Repositories.Interfaces;

namespace PizzaHut.PizzaApp.Data
{
    public class UnitOfWork
    {
        private readonly PizzaAppDBContext _pizzaAppDBContext;
        private readonly IPizzaRepository _pizzaRepository;
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IPizzaIngredientRepository _pizzaIngredientRepository;
        public UnitOfWork(PizzaAppDBContext pizzaAppDBContext)
        {
            _pizzaAppDBContext = pizzaAppDBContext;
            _pizzaRepository = new PizzaRepository(pizzaAppDBContext);
            _ingredientRepository = new IngredientRepository(pizzaAppDBContext);
            _pizzaIngredientRepository = new PizzaIngredientRepository(pizzaAppDBContext);
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

        public IPizzaRepository PizzaRepository
        {
            get
            {
                return _pizzaRepository;
            }
        }

        public IIngredientRepository IngredientRepository
        {
            get
            {
                return _ingredientRepository;
            }
        }

        public IPizzaIngredientRepository PizzaIngredientRepository
        {
            get
            {
                return _pizzaIngredientRepository;
            }
        }
    }
}
