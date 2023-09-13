using PocFluentMigration.Models;

namespace PocFluentMigration.Infrastructure.Repositories
{
    public interface IStateRepository
    {
        IEnumerable<State> All();
    }
}