using System.Collections.Generic;

namespace ComputerShop.Models.ResponseModels
{
    public class ConfigurationResponse : BaseResponseModel
    {
        public IEnumerable<ConfigurationModel> Configurations { get; set; }
    }
}
