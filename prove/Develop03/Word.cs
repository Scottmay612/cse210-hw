class Word
{
    // Declare attribute to store each word.
    private string _word;
    
    // Create constructor for a Word object.
    public Word(string word)
    {
        // Set _word equal to the word input.
        _word = word;
    }
    public void DisplayWord()
    {
        // Display each word with " " after to make the full string.
        Console.Write(_word + " ");
    }
}