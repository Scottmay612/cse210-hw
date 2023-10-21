class Reference
{
    // Declare attribute to store the book name.
    private string _book;

    // Declare attribute to store the chapter number.
    private string _chapter;

    // Declare attribute to store the start verse number.
    private string _startVerse;

    // Declare attribute to store the end verse number.
    private string _endVerse;

    // Create constructor to handle the case where there is only one verse.
    public Reference(string book, string chapter, string startVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
    }

    // Create Constructor to handle the case where there are is a range of 
    // verses.
    public Reference(string book, string chapter, string startVerse, 
                     string endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    public void DisplayReference()
    {
        // Print out correctly formatted scripture reference depending on if 
        // there is one verse or multiple verses.
        if (_endVerse == null)
        {
            // Display the book chapter and verse in this format: John 3:16.
            Console.WriteLine($"{_book} {_chapter}:{_startVerse}");
        }
        else
        {
            // Display the book chapter and verses in this format: 
            // Proverbs 3:5-6.
            Console.WriteLine($"{_book} {_chapter}:{_startVerse}-{_endVerse}");
        }
    }
}