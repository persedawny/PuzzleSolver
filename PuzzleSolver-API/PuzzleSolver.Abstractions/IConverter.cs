namespace PuzzleSolver.Abstractions
{
    public interface IConverter<T>
    {
        public string Convert(T value);
        public T Deserialize(string convertValue);
    }
}
