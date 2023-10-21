class Word
{
    private string _word;
    public Word(string word)
    {
        _word = word;
    }
    public void DisplayWord()
    {
        Console.Write(_word + " ");
    }
}