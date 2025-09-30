using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_API_Note.Data;
using Project_API_Note.DataModel;
using Project_API_Note.Helper;

namespace Project_API_Note.ApiController
{
    public class UserLoginApiController : UserLoginController
    {
        public UserLoginApiController(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        [HttpPost(UserLoginHelper.URL.Register)]
        public override  Task<ActionResult> Register(UserLoginDataModel model)
        {
            return base.Register(model);
        }
        [HttpGet(UserLoginHelper.URL.IsLoginSuccess)]
        public override Task<ActionResult> IsLoginSuccess(UserLoginDataModel model)
        {
            return base.IsLoginSuccess(model);
        }

        [HttpPost(UserLoginHelper.URL.Update)]
        public override Task<ActionResult> Update(UserLoginDataModel model)
        {
            return base.Update(model);
        }

        [HttpGet(UserLoginHelper.URL.Delete)]
        public override Task<ActionResult> Delete(Guid id)
        {
            return base.Delete(id);
        }
    }
}
