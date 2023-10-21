class Scripture
{
    private string _text = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.";
    // private string _text = "Trust in the lord with all thine heart and lean not unto thine own understanding.";
    private List<Word> _words = new List<Word>();
    private List<int> _wordCount = new List<int>();
    public Scripture()
    {
        string[]words = _text.Split(" ");
        int count = 0;
        foreach(string word in words)
        {
            _words.Add(new Word(word));
            _wordCount.Add(count);
            count += 1;
        }
    }
    // public bool CheckNumber()
    // {
    //     return _wordCount.Count >= 0;
    // }
    public void RandomString()
    {
        Random randomNumber = new Random();
        int size = _wordCount.Count;
        int wordIndex = randomNumber.Next(size);
        if (size != 0)
        {
            _words[_wordCount[wordIndex]] = new Word("____");
            _wordCount.RemoveAt(wordIndex);
        }
    }
    public int GetWordCount()
    {
        int listSize = _wordCount.Count();
        return listSize;
    }
    // public string Text{
    //     get {return _text;}
    // // }
    // public List<int> GetWordCount()
    // {
    //     return _wordCount;
    // }
    public void Display()
    {
        foreach (Word word in _words)
        {
            word.DisplayWord();
        }
    }
}