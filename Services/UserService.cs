using corewebapi.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace corewebapi.Services
{
    public class UserService
    {
        private readonly IMongoCollection<UserData> userData;

        public UserService(IOptions<UserDBSettings> userDatabaseSettings)
        {
            var mongoclient = new MongoClient(userDatabaseSettings.Value.ConnectionString);

            var mongodatabase = mongoclient.GetDatabase(userDatabaseSettings.Value.DatabaseName);

            userData = mongodatabase.GetCollection<UserData>(userDatabaseSettings.Value.UserCollectionName);
        }

        public List<UserData> Get() => 
             userData.Find(_ => true).ToList();

        public UserData GetByID(String LoginID)=>
            userData.Find(x=>x.LoginID.Equals(LoginID)).FirstOrDefault();
            

        public async Task CreateAsync(UserData newBook) =>
            await userData.InsertOneAsync(newBook);

    }
}
