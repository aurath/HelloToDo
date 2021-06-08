
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace HelloToDo
{
    public interface ITodoTaskSerializer
    {
        IEnumerable<ToDoTask> Read(Stream inputStream);

        IEnumerable<ToDoTask> Read(FileInfo file);

        IEnumerable<ToDoTask> Read(string text);

        void Write(Stream stream, IEnumerable<ToDoTask> tasks);

        void Write(FileInfo file, IEnumerable<ToDoTask> tasks);

        string Write(IEnumerable<ToDoTask> tasks);
    }

    public class ToDoTaskJsonSerializer : ITodoTaskSerializer
    {
        private readonly JsonSerializerOptions _options = new()
        {
            WriteIndented = true
        };

        public IEnumerable<ToDoTask> Read(Stream stream)
        {
            using var reader = new StreamReader(stream);
            var json = reader.ReadToEnd();
            return Read(json);
        }

        public IEnumerable<ToDoTask> Read(FileInfo file) => Read(file.OpenRead());

        public IEnumerable<ToDoTask> Read(string text) => JsonSerializer.Deserialize<List<ToDoTask>>(text);

        public void Write(Stream stream, IEnumerable<ToDoTask> tasks)
        {
            using var writer = new StreamWriter(stream);
            var json = Write(tasks);
            writer.Write(json);
        }

        public void Write(FileInfo file, IEnumerable<ToDoTask> tasks)
        {
            using var stream = file.Open(FileMode.Create);
            Write(stream, tasks);
        }

        public string Write(IEnumerable<ToDoTask> tasks) => JsonSerializer.Serialize(tasks.ToList(), _options);
    }
}
