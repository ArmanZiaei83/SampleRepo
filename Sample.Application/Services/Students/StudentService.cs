using System.Threading.Tasks;
using Sample.Application.Contracts.Repositories;
using Sample.Application.Contracts.Services;
using Sample.Application.ViewModel;
using Sample.Domain;

namespace Sample.Application.Services.Students
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Add(AddStudentDto dto)
        {
            var student = new Student
            {
                Name = dto.Name,
                NationalCode = dto.NationalCode,
                PhoneNumber = dto.PhoneNumber
            };

            _repository.Add(student);
            await _repository.Save();

            return student.Id;
        }
    }
}