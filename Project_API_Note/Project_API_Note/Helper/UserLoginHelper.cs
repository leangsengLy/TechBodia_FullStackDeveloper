using Project_API_Note.ApiReponse;
using System.Reflection.Metadata.Ecma335;

namespace Project_API_Note.Helper
{
    public class UserLoginHelper
    {
        public static class Message
        {
            public static ApiResponse InvalidData => new ApiResponse("Invalid Data","",false,"invalid_data");
            public static ApiResponse NotFound => new ApiResponse("Data was not found!","",false,"data_was_not_found");
            public static ApiResponse SomethingWhenWrong => new ApiResponse("Something when wrong.","",false,"data_was_not_found");
            public static ApiResponse InterServerError => new ApiResponse( "Internal Server Error", "",false,"internal_server_error");
            public static ApiResponse EmailExisted => new ApiResponse( "Email already existed", "",false,"email_already_existed");
        }
        public static class URL
        {
            public const string Register = "api/login/register";
            public const string Update = "api/login/update";
            public const string Delete = "api/login/delete";
            public const string IsLoginSuccess = "api/login/is_login_success";
        }
    }
}
