using System.Net;

namespace ComputerShop.Models.ResponseModels
{
    public class BaseResponseModel
    {
        public string ResponseMessage { get; set; }
        public HttpStatusCode ResponseCode { get; set; } = HttpStatusCode.OK;

        public BaseResponseModel() { }

        public BaseResponseModel(string message, HttpStatusCode httpCode)
        {
            ResponseMessage = message;
            ResponseCode = httpCode;
        }
    }
}
