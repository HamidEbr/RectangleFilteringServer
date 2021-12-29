using Dapper;
using Domain.Core.Models;
using Domain.Core.Repositories;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Dapper.Repositories
{
    public class RectangleRepository : BaseRepository, IRectangleRepository
    {
        public RectangleRepository(IDbConnection connection) : base(connection)
        {
        }

        public async Task<IEnumerable<RectangleModel>> GetAllAsync()
        {
            return await _connection.QueryAsync<RectangleModel>("select * from rectangle");
        }

        public async Task<long> InsertAsync(RectangleModel rectangleModel)
        {
            var sql = "insert into rectangle (x, y, width, height, time) values (@x, @y, @width, @height, @time)";
            var parameters = new DynamicParameters();
            parameters.Add("@x", rectangleModel.X);
            parameters.Add("@y", rectangleModel.Y);
            parameters.Add("@width", rectangleModel.Width);
            parameters.Add("@height", rectangleModel.Height);
            parameters.Add("@time", rectangleModel.Time);
            var result = await _connection.ExecuteAsync(sql, parameters);
            return result;
        }

        protected override void CheckIfTableNotExists()
        {
            string sql = "create table if not exists rectangle (id integer primary key autoincrement, x int, y int, width int, height int, time datetime)";
            _connection.Open();
            SQLiteCommand command = new(sql, (SQLiteConnection)_connection);
            command.ExecuteNonQuery();
            _connection.Close();
        }
    }
}
