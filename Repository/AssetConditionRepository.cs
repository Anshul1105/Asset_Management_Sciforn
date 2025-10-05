using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asset_Management_Sciforn.Data
{
    public class AssetConditionRepository : IAssetConditionRepository
    {
        private readonly IConfiguration _configuration;

        public AssetConditionRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<AssetCondition?> GetByIdAsync(int id)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            string sql = "SELECT * FROM AssetCondition WHERE Id = @Id";
            return await connection.QueryFirstOrDefaultAsync<AssetCondition>(sql, new { Id = id });
        }

        public async Task<IEnumerable<AssetCondition>> GetAllAsync()
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            string sql = "SELECT * FROM AssetCondition";
            return await connection.QueryAsync<AssetCondition>(sql);
        }
    }
}
