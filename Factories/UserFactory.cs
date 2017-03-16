using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using beltexam4.Models;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;
using beltexam4.ViewModels;
using Microsoft.AspNetCore.Identity;
namespace beltexam4.Factory
{
    public class UserFactory : IFactory<User>
    {
        private readonly IOptions<MySqlOptions> mysqlConfig;

        public UserFactory(IOptions<MySqlOptions> conf)
        {
            mysqlConfig = conf;
        }

        internal IDbConnection Connection
        {
            get
            {
                return new MySqlConnection(mysqlConfig.Value.ConnectionString);
            }
        }

        public User Add(RegisterViewModel model)
        {
            if(FindByEmail(model.email) == null) {
                 PasswordHasher<RegisterViewModel> hash = new PasswordHasher<RegisterViewModel>();
                 User user = new User {
                     name = model.name,
                     alias = model.alias,
                     email = model.email,
                     password = hash.HashPassword(model, model.password)
                 };
            using (IDbConnection dbConnection = Connection)
            {
                string query = "INSERT INTO users (name, alias, email, password, created_at, updated_at, posts, likes) VALUES (@name, @alias, @email, @password, NOW(), NOW(), 0, 0)";
                dbConnection.Open();
                dbConnection.Execute(query, user);
                return dbConnection.Query<User>("SELECT * FROM users WHERE email = @email", new { email = model.email }).FirstOrDefault();
            }
            }
        return null;
        }

        public IEnumerable<User> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<User>("SELECT * FROM users");
            }
        }
        public User FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<User>("SELECT * FROM users WHERE id = @id", new { id = id }).FirstOrDefault();
            }
        }

        public User FindByEmail(string email)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<User>("SELECT * FROM users WHERE email = @email", new { email = email }).FirstOrDefault();
            }
        }

    }
}