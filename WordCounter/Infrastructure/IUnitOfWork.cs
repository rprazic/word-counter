using System.Threading.Tasks;

namespace WordCounter.Infrastructure
{
    public interface IUnitOfWork
    {
        ITextDataRepository TextData { get; }

        Task<int> SaveChangesAsync();
    }
}
