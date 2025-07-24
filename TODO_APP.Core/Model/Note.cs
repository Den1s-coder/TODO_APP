namespace TODO_APP.Core.Model
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }


        public Note() { } // for EF

        public Note(int id, string title, string desc, Guid userId)
        {
            Id = id;
            Title = title;
            Description = desc;
            UserId = userId;
        }
    }
}
