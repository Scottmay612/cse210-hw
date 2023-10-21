class Reference
{
    private string _book;
    private string _chapter;
    private string _startVerse;
    private string _endVerse;
    public Reference(string book, string chapter, string startVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
    }
    public Reference(string book, string chapter, string startVerse, string endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }
    public void GetReference()
    {
        if (_endVerse == null)
        {
            Console.WriteLine($"{_book} {_chapter}: {_startVerse}");
        }
        else
        {
            Console.WriteLine($"{_book} {_chapter}:{_startVerse}-{_endVerse}");
        }
    }
}