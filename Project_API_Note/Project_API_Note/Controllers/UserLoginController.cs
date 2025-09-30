using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_API_Note.ApiReponse;
using Project_API_Note.DataModel;
using Project_API_Note.Helper;
using System.Net;

namespace Project_API_Note.Data
{
    public class UserLoginController : ControllerBase
    {
        protected readonly ApplicationDbContext _db;

        // ✅ Constructor injection
        public UserLoginController(ApplicationDbContext db)
        {
            _db = db;
        }
       
        public virtual async Task<ActionResult> Register([FromBody] UserLoginDataModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Email) && string.IsNullOrEmpty(model.Password))
                {
                    return Ok(new LSApiResponse(UserLoginHelper.Message.InvalidData, HttpStatusCode.BadRequest).SetDetail("Email or Password are required."));
                }
                if(_db.LSUSER_LOGINs.Any(s => s.EMAIL == model.Email))
                {
                    return Ok(new LSApiResponse(UserLoginHelper.Message.EmailExisted, HttpStatusCode.BadRequest).SetDetail());
                }
                var result = await UserLoginData.Register(model, _db);
                return Ok(result);
            }
            catch (Exception ex) {
                return  Ok(new LSApiResponse(UserLoginHelper.Message.InterServerError, HttpStatusCode.InternalServerError).SetDetail());
            }
        }

        public virtual async Task<ActionResult> IsLoginSuccess([FromBody] UserLoginDataModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Email) && string.IsNullOrEmpty(model.Password))
                {
                    return Ok(new LSApiResponse(UserLoginHelper.Message.InvalidData, HttpStatusCode.BadRequest).SetDetail("Email or Password are required."));
                }
                var find = _db.LSUSER_LOGINs.FirstOrDefault(s => s.EMAIL == model.Email);
                if(find == null) return Ok(new LSApiResponse(UserLoginHelper.Message.NotFound, HttpStatusCode.NotFound).SetDetail());
                var result = await UserLoginData.IsLoginSuccess(model, _db);
                return Ok(result);
            }
            catch (Exception ex) {
                return  Ok(new LSApiResponse(UserLoginHelper.Message.InterServerError, HttpStatusCode.InternalServerError).SetDetail());
            }
        }

        public virtual async Task<ActionResult> Update([FromBody] UserLoginDataModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Email) && string.IsNullOrEmpty(model.Password)) return Ok(new LSApiResponse(UserLoginHelper.Message.InvalidData, HttpStatusCode.BadRequest).SetDetail("Email or Password are required."));
                var find = await _db.LSNOTEs.FirstOrDefaultAsync(s => s.ID == model.Id);
                if(find==null) return Ok(new LSApiResponse(UserLoginHelper.Message.NotFound, HttpStatusCode.InternalServerError).SetDetail());
                var result = await UserLoginData.Update(model, _db);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new LSApiResponse(UserLoginHelper.Message.InterServerError, HttpStatusCode.InternalServerError).SetDetail());
            }
        }

        public virtual async Task<ActionResult> Delete(Guid id)
        {
            if (string.IsNullOrEmpty(id.ToString())) return Ok(new LSApiResponse(UserLoginHelper.Message.InvalidData, HttpStatusCode.BadRequest).SetDetail("Id is required."));
            var find = await _db.LSUSER_LOGINs.FirstOrDefaultAsync(s => s.ID == id);
            if (find == null) return Ok(new LSApiResponse(UserLoginHelper.Message.NotFound, HttpStatusCode.InternalServerError).SetDetail());
            var isDeleteSuccess = await UserLoginData.Delete(id, _db);
            return Ok(isDeleteSuccess);
        }
    }
}
