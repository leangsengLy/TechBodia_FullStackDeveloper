namespace Project_API_Note.DataModel.Notes
{
    public class NotesFilterDataModel
    {
        public string Search { get; set; }
        public int Pages { get; set; }
        public int Records { get; set; }
        public string OrderBy { get; set; }
        public string OrderDir { get; set; }
    }
}
