using Newtonsoft.Json;
using PuzzleSolver.Abstractions;

namespace PuzzleSolver.Core.Converters
{
    public class JsonConverter<T> : IConverter<T>
    {
        public JsonConverter() { }

        public string Convert(T value) => JsonConvert.SerializeObject(value);

        public T Deserialize(string convertValue) => JsonConvert.DeserializeObject<T>(convertValue);
    }
}
