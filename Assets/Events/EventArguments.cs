
public class KeyPressedEventArgs : System.EventArgs
{
    public UnityEngine.KeyCode PressedKey { get; private set; }
    public KeyPressedEventArgs(UnityEngine.KeyCode pressedKey)
    {
        this.PressedKey = pressedKey;
    }
}

public class WordEventArgs : System.EventArgs
{
    public Word Word { get; private set; }
    public WordEventArgs(Word word)
    {
        this.Word = word;
    }
}

public class ScoreEventArgs : System.EventArgs
{
    public int Score { get; private set; }
    public ScoreEventArgs(int score)
    {
        this.Score = score;
    }
}
