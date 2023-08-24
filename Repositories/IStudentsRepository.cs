using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Students.Api.Entities;

namespace Students.Api.Repositories
{
    public interface IStudentsRepository
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student?> GetAsync(Guid id);
        Task CreateAsync(Student student);
        Task UpdateAsync(Student student);
        Task DeleteAsync(Guid id);
    }
}