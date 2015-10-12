using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace mongoLog
{
    class DBHelper
    {
        public string ConnString = "mongodb://125.209.198.141:27017";
        MongoClient Client;
        IMongoDatabase DataBase;
        IMongoCollection<User> Users;
        IMongoCollection<Data> Datas;
        
        public void Init()
        {
            Client = new MongoClient(ConnString);
            DataBase = Client.GetDatabase("mongoLog");
            Users = DataBase.GetCollection<User>("Users");
            Datas = DataBase.GetCollection<Data>("Datas");
        }

        public async void InsertLog(LogMsg logMsg)
        {
            var builder = Builders<User>.Filter;
            var userFilter = builder.Eq("UserId", logMsg.UserId) & builder.Eq("Password", logMsg.Password);
            var userCount = await Users.Find<User>(userFilter).CountAsync();
            User user = logMsg.ToUser();
            Data data = logMsg.ToData();

            if(userCount == 0)
            {
                await Users.InsertOneAsync(user);
                data.UserId = user.Id;
                await Datas.InsertOneAsync(data);
            }
            else
            {
                user = await Users.Find<User>(userFilter).FirstAsync();
                var dataFilter = Builders<Data>.Filter.Eq("Name", logMsg.Name) & Builders<Data>.Filter.Eq("UserId", user.Id);
                var dataCount = await Datas.Find<Data>(dataFilter).CountAsync();
                if(dataCount == 0)
                {
                    var userUpdate = Builders<User>.Update.Push("OwnDataNames", logMsg.Name);
                    await Users.UpdateOneAsync(userFilter, userUpdate);
                    data.UserId = user.Id;
                    await Datas.InsertOneAsync(data);
                }
                else
                {
                    var dataUpdate = Builders<Data>.Update.Push("Logs", logMsg.ToLog());
                    await Datas.UpdateOneAsync(dataFilter, dataUpdate);
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
            Msg = new Dictionary<string,string>();
        }
        public int Level { get; set; }
        public DateTime Time { get; set; }
        public Dictionary<string, string> Msg { get; set; }
    }

}
