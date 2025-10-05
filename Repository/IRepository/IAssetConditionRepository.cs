using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asset_Management_Sciforn.Data
{
    public interface IAssetConditionRepository
    {
        Task<AssetCondition?> GetByIdAsync(int id);
        Task<IEnumerable<AssetCondition>> GetAllAsync();
    }
}