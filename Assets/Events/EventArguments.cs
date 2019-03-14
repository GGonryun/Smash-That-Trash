public class DataEventArgs<T> : System.EventArgs
{
    public T Data { get; protected set; }

    public DataEventArgs(T data)
    {
        Data = data;
    }
}
