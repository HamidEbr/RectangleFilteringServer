using Domain.Core.Repositories;
using Infrastructure.Repository.Dapper.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SQLite;

namespace Infrastructure.Repository.Dapper
{
    public static class DependancyInjection
    {
        public static void RegisterRepository(this IServiceCollection services)
        {
            services.AddScoped<IDbConnection>(x => new SQLiteConnection("Data Source=rectangleDatabase.sqlite;Version=3;"));
            services.AddScoped<IRectangleRepository, RectangleRepository>();
            //SQLiteConnection.CreateFile("RectangleDatabase.sqlite");
            //SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=RectangleDatabase.sqlite;Version=3;");
            //m_dbConnection.Open();

            //string sql = "create table highscores (name varchar(20), score int)";

            //SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            //command.ExecuteNonQuery();

            //sql = "insert into highscores (name, score) values ('Me', 9001)";

            //command = new SQLiteCommand(sql, m_dbConnection);
            //command.ExecuteNonQuery();

            //m_dbConnection.Close();


        }
    }
}
