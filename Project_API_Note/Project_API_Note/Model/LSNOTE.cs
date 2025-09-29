using System.ComponentModel.DataAnnotations;

namespace Project_API_Note.Model
{
    public class LSNOTE
    {
        public Guid ID { get; set; }
        [StringLength(40)]
        public required string TITLE { get; set; }
        [StringLength(256)]
        public required string CONTENT { get; set; }
        public required DateTime CREATED_AT { get; set; }
        public DateTime? UPDATED_AT { get; set; }
    }
}
