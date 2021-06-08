using CommandLine;
using HelloToDo.Terminal.Verbs;

namespace HelloToDo.Terminal
{
    public class Program
    {
        public const string DataDirectoryName = @"ToDo";
        public const string SettingsFileName = @"settings.yml";
        public const string TaskFileName = "tasks.json";

        public static void Main(string[] args)
        {
            Parser.Default
                .ParseArguments<ListVerb, AddVerb, CheckVerb, RemoveVerb, CleanVerb>(args)
                .WithParsed<VerbBase>(o => o.Execute());
        }
    }
}
