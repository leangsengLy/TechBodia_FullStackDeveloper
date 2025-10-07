using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Runtime.CompilerServices;

namespace Project_API_Note.ApiReponse
{
    public class LSApiResponse:ActionResult
    {
        public ApiResponse apiResponse { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public ActionResult actionResult { get; set; }

        public  LSApiResponse(ApiResponse apiResponse ,HttpStatusCode statusCode) {
            this.apiResponse = apiResponse;
            this.StatusCode = statusCode;
        }

        public LSApiResponse SetDetail(dynamic Message)
        {
            this.apiResponse.Detail = Message;
            return this;

        }
        public LSApiResponse SetDetail(string Message="")
        {
            this.apiResponse.Detail = Message;
            return this;

        }
    }
}
