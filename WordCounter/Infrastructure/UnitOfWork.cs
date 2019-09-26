using System.Threading.Tasks;

namespace WordCounter.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly WordCountDbContext _context;

        private ITextDataRepository _textData;

        public UnitOfWork(WordCountDbContext context)
        {
            _context = context;
        }

        public ITextDataRepository TextData
        {
            get
            {
                if (_textData == null)
                    _textData = new TextDataRepository(_context);

                return _textData;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
