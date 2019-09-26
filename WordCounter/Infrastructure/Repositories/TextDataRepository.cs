namespace WordCounter.Infrastructure
{
    public class TextDataRepository : Repository<TextData>, ITextDataRepository
    {
        public TextDataRepository(WordCountDbContext context) : base(context) { }
    }
}
