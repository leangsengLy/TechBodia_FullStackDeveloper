namespace Project_API_Note.DataModel.Notes
{
    public class NotesDataModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateNow { get; set; }
    }
}
