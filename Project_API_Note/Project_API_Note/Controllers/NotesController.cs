using Microsoft.AspNetCore.Mvc;
using Project_API_Note.DataModel;

namespace Project_API_Note.Data
{
    public class NotesController : ControllerBase
    {
        protected readonly ApplicationDbContext _db;

        // ✅ Constructor injection
        public NotesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public virtual ActionResult List(NotesFilterDataModel filter)
        {   
            var result =  NotesData.List(filter,_db);
            return Ok(result);
        }
        public virtual ActionResult Create(NotesDataModel model)
        {
            return Ok("Create");
        }
        public virtual ActionResult Update(NotesDataModel model)
        {
            return Ok("Update");
        }
        public virtual ActionResult Delete(long id)
        {
            return Ok("Delete");
        }
    }
}
