using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asset_Management_Sciforn.Data
{
    public class AssetStatusRepository : IAssetStatusRepository
    {
        private readonly IConfiguration _configuration;

        public AssetStatusRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<AssetStatus?> GetByIdAsync(int id)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            string sql = "SELECT * FROM AssetStatus WHERE Id = @Id";
            return await connection.QueryFirstOrDefaultAsync<AssetStatus>(sql, new { Id = id });
        }

        public async Task<IEnumerable<AssetStatus>> GetAllAsync()
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            string sql = "SELECT * FROM AssetStatus";
            return await connection.QueryAsync<AssetStatus>(sql);
        }
    }
}
