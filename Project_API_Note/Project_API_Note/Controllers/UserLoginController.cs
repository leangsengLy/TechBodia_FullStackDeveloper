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
        private readonly ApplicationDbContext _db;

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
                if (_db.LSUSER_LOGINs.Any(s => s.EMAIL == model.Email))
                {
                    return Ok(new LSApiResponse(UserLoginHelper.Message.EmailExisted, HttpStatusCode.BadRequest).SetDetail());
                }
                var result = await UserLoginData.Register(model, _db);
                return Ok(result);
            }
            catch (Exception ex) {
                return  Ok(new LSApiResponse(UserLoginHelper.Message.InterServerError, HttpStatusCode.InternalServerError).SetDetail(ex));
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
                var result = await UserLoginData.IsLoginSuccess(model, _db);
                return Ok(result);
            }
            catch (Exception ex) {
                return Ok(new LSApiResponse(UserLoginHelper.Message.InterServerError, HttpStatusCode.InternalServerError).SetDetail(ex));
            }
        }
    }
}
