using harry.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace harry.Services
{
    public class userService
    {
        private readonly IMongoCollection<user> _users;

        public userService(IHarryDatabase settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<user>(settings.CollectionName);
        }

        public List<user> Get() =>
            _users.Find(user =>true).ToList();


        public user Create(user user)
        {
            _users.InsertOne(user);
            return user;
        }

        public void Update(string id, user userIn) =>
            _users.ReplaceOne(user => user.Id == id, userIn);

        public void Remove(user userIn) =>
            _users.DeleteOne(user => user.Id == userIn.Id);

        public void Remove(string id) => 
            _users.DeleteOne(user => user.Id == id);
    }
}