namespace ToDoListApp.Models
{
    public class Task
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string? Description { get; set; }


        public bool IsCompleted { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime Deadline { get; set; }

        public DateTime CompletedOn { get; set; }
    }
}
