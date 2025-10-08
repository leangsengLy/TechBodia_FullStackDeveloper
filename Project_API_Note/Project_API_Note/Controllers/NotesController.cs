using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_API_Note.ApiReponse;
using Project_API_Note.DataModel.Notes;

using Project_API_Note.Helper;
using System.Net;

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
        public virtual async Task<ActionResult> List([FromBody] NotesFilterDataModel filter)
        {
            filter.Records = filter.Records == 0 ? filter.Records : 10;
            filter.Pages = filter.Pages == 0 ? filter.Pages : 1;
            var result = await NotesData.List(filter, _db);
            return Ok(result);
        }
        public virtual async Task<ActionResult> Create([FromBody] NotesDataModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Title)) return Ok(new LSApiResponse(NotesHelper.Message.InvalidData, HttpStatusCode.InternalServerError).SetDetail("Title is required."));
                var result = await NotesData.Create(model, _db);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new LSApiResponse(NotesHelper.Message.InterServerError, HttpStatusCode.InternalServerError).SetDetail(ex.Message));
            }
        }
        public virtual async Task<ActionResult> Update([FromBody] NotesDataModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Id.ToString())) return Ok(new LSApiResponse(NotesHelper.Message.InvalidData, HttpStatusCode.InternalServerError).SetDetail("Id is required."));
                var find = await _db.LSNOTEs.FirstOrDefaultAsync(s => s.ID == model.Id);
                if (find == null) return Ok(new LSApiResponse(NotesHelper.Message.NotFound, HttpStatusCode.InternalServerError).SetDetail());
                var result = await NotesData.Update(model, _db);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new LSApiResponse(NotesHelper.Message.InterServerError, HttpStatusCode.InternalServerError).SetDetail(ex.Message));
            }
        }
        public virtual async Task<ActionResult> Delete(Guid id)
        {

            if (string.IsNullOrEmpty(id.ToString())) return Ok(new LSApiResponse(NotesHelper.Message.InvalidData, HttpStatusCode.InternalServerError).SetDetail("Id is required."));
            var find = await _db.LSNOTEs.FirstOrDefaultAsync(s => s.ID == id);
            if (find == null) return Ok(new LSApiResponse(NotesHelper.Message.NotFound, HttpStatusCode.InternalServerError).SetDetail());
            var isDeleteSuccess = await NotesData.Delete(id, _db);
            return Ok(isDeleteSuccess);
        }
    }
}
