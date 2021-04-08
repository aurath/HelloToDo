using System;

namespace HelloToDo
{
    public class ToDoTask
    {
        public ToDoTask(string title)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            CreatedAt = DateTime.Now;
        }

        public string Title { get; }

        public bool Complete
        {
            get => _complete;
            set
            {
                _complete = value;
                if (value) CompletedAt = DateTime.Now;
            }
        }

        private bool _complete;

        public DateTime CreatedAt { get; }

        public DateTime? CompletedAt { get; private set; }
    }
}
