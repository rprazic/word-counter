namespace WordCounter.Core
{
    public class WordCounter
    {
        public string Text { get { return _text; } }

        private readonly string _text;

        private int _wordCount = 0;

        private int _index = 0;

        public WordCounter(string text)
        {
            _text = text;
        }

        public int CountWords()
        {
            FindNextWord();
            while (_index < _text.Length)
            {
                IsCurrentWord();
                _wordCount++;
                FindNextWord();
            }
            return _wordCount;
        }

        private void IsCurrentWord()
        {
            while (_index < _text.Length && !char.IsWhiteSpace(_text[_index]))
                _index++;
        }

        private void FindNextWord()
        {
            while (_index < _text.Length && char.IsWhiteSpace(_text[_index]))
                _index++;
        }
    }
}
