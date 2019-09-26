namespace WordCounter.Infrastructure
{
    public class TextData : IEntity
    {
        public int Id { get; set; }

        public string Text { get; set; }
    }
}
