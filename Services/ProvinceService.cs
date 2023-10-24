using AzureFunction.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureFunction.Services
{
    public interface IProvinceService
    {
        Task<List<Province>> GetProvinces();
    }
    public class ProvinceService : IProvinceService
    {
        public ProvinceService()
        {
        }

        public async Task<List<Province>> GetProvinces()
        {
            var result = new Province().GetProvinces;
            return result;
        }
    }
}
