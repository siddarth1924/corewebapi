using corewebapi.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace corewebapi.Services
{
    public class StudentService
    {
        private readonly IMongoCollection<StudentsData> studentData;

        public StudentService(IOptions<StudentDBSettings> studentDatabaseSettings)
        {
            var mongoclient = new MongoClient(studentDatabaseSettings.Value.ConnectionString);

            var mongodatabase = mongoclient.GetDatabase(studentDatabaseSettings.Value.DatabaseName);

            studentData = mongodatabase.GetCollection<StudentsData>(studentDatabaseSettings.Value.StudentCollectionName);
        }

        public List<StudentsData> Get() => 
             studentData.Find(_ => true).ToList();

        public async Task CreateAsync(StudentsData newBook) =>
            await studentData.InsertOneAsync(newBook);

    }
}
