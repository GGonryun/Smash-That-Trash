public interface ITargetter<T> where T : ITargettable
{
    T Target { get; set; }
}