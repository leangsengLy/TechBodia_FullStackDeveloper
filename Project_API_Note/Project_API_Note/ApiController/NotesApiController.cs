using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_API_Note.Data;
using Project_API_Note.DataModel.Notes;
using Project_API_Note.Helper;

namespace Project_API_Note.ApiController
{
    public class NotesApiController : NotesController
    {
        private readonly ApplicationDbContext _db;
        public NotesApiController(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
       
        [HttpPost(NotesHelper.URL.List)]
        public override Task<ActionResult> List(NotesFilterDataModel filter)
        {
            return base.List(filter);
        }

        [HttpPost(NotesHelper.URL.Create)]
        public override  Task<ActionResult> Create(NotesDataModel model)
        {
            return base.Create(model);
        }

        [HttpPost(NotesHelper.URL.Update)]
        public override Task<ActionResult> Update(NotesDataModel model)
        {
            return base.Update(model);
        }
        [HttpGet(NotesHelper.URL.Delete)]
        public override Task<ActionResult> Delete(Guid id)
        {
            return base.Delete(id);
        }
    }
}
