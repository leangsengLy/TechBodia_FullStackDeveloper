using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_API_Note.Model
{
    public class LSUSER_LOGIN
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        [StringLength(100)]
        public  string EMAIL { get; set; }
        public  string PASSWORD { get; set; }
        public  DateTime CREATED_AT { get; set; }
        public DateTime? UPDATED_AT { get; set; }
      
    }
}
