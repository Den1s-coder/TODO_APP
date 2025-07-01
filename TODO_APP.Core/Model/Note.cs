namespace TODO_APP.Core.Model
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime? UpdateAt { get; set; }

        public Note(int id, string title, string desc)
        {
            Id = id;
            Title = title;
            Description = desc;
        }
    }
}
