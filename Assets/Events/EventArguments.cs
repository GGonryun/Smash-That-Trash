
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

public class EntryEventArgs : System.EventArgs
{
    public Entry Entry { get; private set; }
    public EntryEventArgs(Entry entry)
    {
        this.Entry = entry;
    }
}
