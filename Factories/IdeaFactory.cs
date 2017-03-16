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
    public class IdeaFactory : IFactory<Idea>
    {
        private readonly IOptions<MySqlOptions> mysqlConfig;

        public IdeaFactory(IOptions<MySqlOptions> conf)
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

        public Idea FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Idea>("SELECT * FROM ideas WHERE id = @id", new { id = id }).FirstOrDefault();
            }
        }

        public IEnumerable<Idea> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Idea>("SELECT * FROM ideas ORDER BY likes DESC");
            }
        }

        public void AddIdea(IdeaViewModel ideaModel)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "INSERT INTO ideas (idea, likes, created_at, updated_at, users_id, alias, no_votes) VALUES (@idea, 0, NOW(), NOW(), @users_id, @alias, 0)";
                dbConnection.Open();
                dbConnection.Execute(query, ideaModel);
                string query2 = "UPDATE users SET posts = posts + 1 WHERE id = " +ideaModel.users_id +"";
                dbConnection.Execute(query2);
            }
        }
        
        public void AddLike (int user_id, int idea_id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "UPDATE ideas SET likes = likes + 1 WHERE id = " + idea_id + "";
                string query2 = "INSERT INTO likes (users_id, ideas_id, like_count) VALUES (" + user_id + "," + idea_id + ", 1)";
                string query3 = "UPDATE users SET likes = likes + 1 WHERE id = " + user_id + "";
                dbConnection.Execute(query);
                dbConnection.Execute(query2);
                dbConnection.Execute(query3);
            }
        }
        public void AddVoteNo (int user_id, int idea_id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "UPDATE ideas SET no_votes = no_votes + 1 WHERE id = " + idea_id + "";
                string query2 = "INSERT INTO likes (users_id, ideas_id, no_vote_count) VALUES (" + user_id + "," + idea_id + ", 1)";
                string query3 = "UPDATE users SET no_votes = no_votes + 1 WHERE id = " + user_id + "";
                dbConnection.Execute(query);
                dbConnection.Execute(query2);
                dbConnection.Execute(query3);
            }
        }

        public IEnumerable<Likes> AllLikesForUser (int user_id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Likes>("SELECT * FROM likes WHERE users_id = " + user_id + "");
            }
        }
     

        public IEnumerable<Idea> PostCount()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Idea>("SELECT activities_id, sum(count) as count FROM users_has_activities GROUP BY activities_id");
            }
            
        }

        public IEnumerable<User> AllLikesForIdea(int idea_id)
         {
            using (IDbConnection dbConnection = Connection)
            {
                var query = $"SELECT * FROM users JOIN likes ON id WHERE users.id = likes.users_id AND likes.ideas_id = " + idea_id + "";
                dbConnection.Open();
                var myLikes = dbConnection.Query<User, Likes, User>(query, (user, like) => { user.like = like; return user; }, splitOn: "users_id");
                return myLikes;
            }
        }

        public void Delete(int idea_id, int user_id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var alllikes = AllLikesForIdea(idea_id);
                foreach(var like in alllikes)
                {
                   string query3 = "UPDATE users SET likes = likes - 1 WHERE id = " + like.id + ""; 
                   dbConnection.Execute(query3);
                }

                dbConnection.Open();
                dbConnection.Execute("DELETE FROM likes WHERE ideas_id = " + idea_id +"");
                dbConnection.Execute("DELETE FROM ideas WHERE id = " + idea_id +"");
                string query2 = "UPDATE users SET posts = posts - 1 WHERE id = " + user_id +"";
                dbConnection.Execute(query2);


            }
        }
    }
}