using System;

namespace ComputerShop.Models.ResponseModels
{
    public class AddedResponse : BaseResponseModel
    {
        public Guid Id { get; }

        public AddedResponse(Guid id)
        {
            Id = id;
            ResponseCode = System.Net.HttpStatusCode.Created;
        }
    }
}
