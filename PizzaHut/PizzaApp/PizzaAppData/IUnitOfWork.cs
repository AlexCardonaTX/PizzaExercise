using PizzaHut.PizzaApp.Data.Repositories.Interfaces;

namespace PizzaAppData
{
    public interface IUnitOfWork
    {
        IPizzaRepository PizzaRepository { get; }
        IIngredientRepository IngredientRepository { get; }
        IPizzaIngredientRepository PizzaIngredientRepository { get; }
        void BeginTransaction();
        void CommitTransaction();
        void RollBackTransaction();
        void Save();
    }
}
