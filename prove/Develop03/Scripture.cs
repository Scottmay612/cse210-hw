class Scripture
{
    // Create _text attribute for scripture text.
    private string _text = "For God so loved the world that he gave his one " +
    "and only Son, that whoever believes in him shall not perish but have " +
    "everlasting life.";

    // Second text for multiple verses:
    // private string _text = "Trust in the Lord with all thine heart; and " +
    // "lean not unto thine own understanding. In all thy ways acknowledge " +
    // "him, and he shall direct thy paths.";

    // Create List of Word objects called _words.
    private List<Word> _words = new List<Word>();

    //Create List of integers that matches the _words list.
    private List<int> _wordCount = new List<int>();

    // Create scripture constructor.
    public Scripture()
    {
        // Split the text into separate words at each space.
        string[]words = _text.Split(" ");

        // Declare count for _wordCount.
        int count = 0;

        foreach(string word in words)
        {
            // Add each word as a new Word object in the _words list.
            _words.Add(new Word(word));
            
            // Add onto the _wordCount list to match the _words list.
            _wordCount.Add(count);

            // The count adds one for each iteration.
            count += 1;
        }
    }
    public void RandomString()
    {
        // Create new random number.
        Random randomNumber = new Random();

        // Create count variable to track iteration count.
        int count = 0;

        while (count <= 2 )
        {
            // Add one to count each iteration.
            count += 1;

            // Size is set to the length of the _wordCount list.
            int size = _wordCount.Count;

            // A random index is picked in the length of the list.
            int wordIndex = randomNumber.Next(size);

            //Only run if size is greater than 0.
            if (size != 0)
            {
                // Replace the original word with underlines.
                _words[_wordCount[wordIndex]] = new Word("____");
                _wordCount.RemoveAt(wordIndex);
            }
        }
    }
    public int GetWordCount()
    {
        // Return the word count to be used in the Program Class.
        return _wordCount.Count();
    }
    public void Display()
    {
        // Display each word with a " " after it to make full line.
        foreach (Word word in _words)
        {
            // Call DisplayWord from the Word Class.
            word.DisplayWord();
        }
    }
}