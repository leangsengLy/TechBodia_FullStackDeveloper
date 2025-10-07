using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_API_Note.Data;
using Project_API_Note.DataModel;
using Project_API_Note.Helper;
using Project_API_Note.Jwt;

namespace Project_API_Note.ApiController
{
    [ApiController]
    public class UserLoginApiController : UserLoginController
    {
        public UserLoginApiController(ApplicationDbContext dbContext, JwtTokenService jwt) : base(dbContext, jwt)
        {
        }

        [HttpPost(UserLoginHelper.URL.Register)]
        public override Task<ActionResult> Register(UserLoginDataModel model)
        {
            return base.Register(model);
        }

        [HttpPost(UserLoginHelper.URL.IsLoginSuccess)]
        public override Task<ActionResult> IsLoginSuccess(UserLoginDataModel model)
        {
            return base.IsLoginSuccess(model);
        }
    }
}
