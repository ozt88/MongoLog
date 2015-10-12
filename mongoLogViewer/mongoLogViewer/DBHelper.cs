using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading;
using System.Threading.Tasks;

namespace mongoLogViewer
{
    class DBHelper
    {
        public DBHelper()
        {
            Client = new MongoClient(ConnString);
            Db = Client.GetDatabase("mongoLog");
            Users = Db.GetCollection<User>("Users");
            Datas = Db.GetCollection<Data>("Datas");
        }

        public string ConnString = "mongodb://125.209.198.141:27017";
        MongoClient Client;
        IMongoDatabase Db;
        IMongoCollection<User> Users;
        IMongoCollection<Data> Datas;

        public async Task<List<string>> Login(string id, string psw)
        {
            var builder = Builders<User>.Filter;
            var filter = builder.Eq("UserId", id) & builder.Eq("Password", psw);
            var ret = await Users.Find<User>(filter).CountAsync();
            if (ret == 0)
                return null;
            else
            {
                User user = await Users.Find<User>(filter).FirstAsync();
                return user.OwnDataNames;
            }

        }

        public async Task<List<Log>> GetData(string id, string psw, string name, int level, DateTime fromTime, DateTime toTime)
        {
            var builder = Builders<User>.Filter;
            var filter = builder.Eq("UserId", id) & builder.Eq("Password", psw);
            var ret = await Users.Find<User>(filter).CountAsync();

            if (ret == 0)
            {
                return null;
            }
            else
            {
                User user = await Users.Find<User>(filter).FirstAsync();
                var dataBuilder = Builders<Data>.Filter;
                var dataFilter = dataBuilder.Eq("UserId", user.Id) & dataBuilder.Eq("Name", name);
                var dataCount = await Datas.Find<Data>(dataFilter).CountAsync();
                if (dataCount == 0)
                {
                    return null;
                }
                else
                {
                    var data = await Datas.Find<Data>(dataFilter).FirstAsync();
                    return data.Logs.Where(x => x.Time >= fromTime && x.Time <= toTime && x.Level >= level).ToList();
                }
            }


        }
    }

    class User
    {
        public User()
        {
            OwnDataNames = new List<string>();
        }
        public ObjectId Id { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public List<string> OwnDataNames { get; set; }
    }

    class Data
    {
        public Data()
        {
            Logs = new List<Log>();
        }
        [MongoDB.Bson.Serialization.Attributes.BsonId]
        public ObjectId Id { get; set; }
        public ObjectId UserId { get; set; }
        public string Name { get; set; }
        public List<Log> Logs { get; set; }
    }

    class Log
    {
        public Log()
        {
            Msg = new Dictionary<string, string>();
        }
        public int Level { get; set; }
        public DateTime Time { get; set; }
        public Dictionary<string, string> Msg { get; set; }
    }
}
