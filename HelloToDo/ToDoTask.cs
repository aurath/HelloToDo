using System;
using System.ComponentModel.DataAnnotations;

namespace HelloToDo
{
    public class ToDoTask
    {
        public ToDoTask(string title)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));

            Hidden = false;
        }

        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Title { get; set; }

        public bool Complete { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? CompletedAt { get; set; }

        public bool Hidden { get; set; }
    }
}
