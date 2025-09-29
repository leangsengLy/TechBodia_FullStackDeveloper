using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_API_Note.Data;
using Project_API_Note.DataModel;
using Project_API_Note.Helper;

namespace Project_API_Note.ApiController
{
    public class NotesApiController : NotesController
    {
        private readonly ApplicationDbContext _db;
        public NotesApiController(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
       
        [HttpGet("api/noted/list")]
        public ActionResult List(NotesFilterDataModel filter)
        {
            return base.List(filter);
        }

        [HttpGet(NotesHelper.URL.Create)]
        public override ActionResult Create(NotesDataModel model)
        {
            return base.Create(model);
        }

        [HttpGet(NotesHelper.URL.Update)]
        public override ActionResult Update(NotesDataModel model)
        {
            return base.Update(model);
        }
        [HttpGet(NotesHelper.URL.Delete)]
        public override ActionResult Delete(long id)
        {
            return base.Delete(id);
        }
    }
}
