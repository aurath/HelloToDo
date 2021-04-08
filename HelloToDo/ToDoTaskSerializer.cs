using System.IO;
using System.Text.Json;

namespace HelloToDo
{
    public interface ITodoTaskSerializer
    {
        ToDoTask Read(string path);

        void Write(string path, ToDoTask task);
    }

    public class ToDoTaskJsonSerializer : ITodoTaskSerializer
    {
        public ToDoTask Read(string path)
        {
            return JsonSerializer.Deserialize<ToDoTask>(path);
        }

        public void Write(string path, ToDoTask task)
        {
            using var stream = new FileStream(path, FileMode.Create);
            using var writer = new Utf8JsonWriter(stream);
            JsonSerializer.Serialize(writer, task);
        }
    }
}
