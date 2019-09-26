using System.Threading.Tasks;

namespace WordCounter.Core
{
    public interface IDatabaseInitializeService
    {
        Task SeedAsync();
    }
}
