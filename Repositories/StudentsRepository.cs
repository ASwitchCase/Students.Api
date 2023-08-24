using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features;
using MongoDB.Bson;
using MongoDB.Driver;
using Students.Api.Entities;
using Students.Api.Settings;

namespace Students.Api.Repositories
{
    public class StudentsRepository : IStudentsRepository
    {
        public const string database_name = "gothicnetRemake";
        public const string collection_name = "Students";
        public readonly IMongoCollection<Student> studentsCollection;
        private readonly FilterDefinitionBuilder<Student> filterBuilder = Builders<Student>.Filter;

        public StudentsRepository(MongoDbSettings settings){
            MongoClient mongoClient = new MongoClient(settings.GetConnectionString());
            IMongoDatabase db = mongoClient.GetDatabase(database_name);
            studentsCollection = db.GetCollection<Student>(collection_name);
        }
        public async Task CreateAsync(Student student)
        {
            await studentsCollection.InsertOneAsync(student);
        }

        public async Task DeleteAsync(Guid id)
        {
            var filter = filterBuilder.Eq(student => student.Id, id);
            await studentsCollection.DeleteOneAsync(filter);
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await studentsCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<Student?> GetAsync(Guid id)
        {
            var filter = filterBuilder.Eq(student => student.Id, id);
            return await studentsCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task UpdateAsync(Student student)
        {
            var filter = filterBuilder.Eq(exsistingStudent => exsistingStudent.Id, student.Id); 
            await studentsCollection.ReplaceOneAsync(filter, student);
        }
    }
}