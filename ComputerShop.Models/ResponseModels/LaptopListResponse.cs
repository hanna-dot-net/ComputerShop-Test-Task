using System.Collections.Generic;

namespace ComputerShop.Models.ResponseModels
{
    public class LaptopListResponse : BaseResponseModel
    {
        public List<LaptopModel> Laptops { get; set; }
    }
}
