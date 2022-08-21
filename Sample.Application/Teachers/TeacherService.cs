using System.Threading.Tasks;
using Sample.Application.Contracts;
using Sample.Application.Contracts.Repositories;
using Sample.Application.Contracts.Services;
using Sample.Application.DTOs;
using Sample.Domain.Entities;

namespace Sample.Application.Teachers
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _repository;

        private readonly IUnitOfWork _unitOfWork;

        public TeacherService(
            IUnitOfWork unitOfWork,
            ITeacherRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<int> Add(AddTeacherDto dto)
        {
            var teacher = new Teacher
            {
                Name = dto.Name,
                NationalCode = dto.NationalCode,
                PhoneNumber = dto.PhoneNumber
            };

            _repository.Add(teacher);
            await _unitOfWork.Complete();
            
            return teacher.Id;
        }
    }
}