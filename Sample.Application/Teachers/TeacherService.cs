using System.Threading.Tasks;
using Sample.Application.DTOs;
using Sample.Application.Exceptions;
using Sample.Application.Interfaces;
using Sample.Application.Interfaces.Repositories;
using Sample.Application.Interfaces.Services;
using Sample.Domain.Entities;
using Sample.Infrastructure.Shared;

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
            ThrowExceptionWhenPhoneNumberIsIncorrect(dto.PhoneNumber);
            ThrowExceptionWhenNationalCodeIsIncorrect(dto.NationalCode);
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
        
        private void ThrowExceptionWhenPhoneNumberIsIncorrect(
            string phoneNumber)
        {
            var isValid = PhoneNumberValidator.IsValid(phoneNumber);
            if (!isValid)
                throw new IncorrectPhoneNumberException();
        }
        
        private void ThrowExceptionWhenNationalCodeIsIncorrect(
            string nationalCode)
        {
            var isValid = NationalCodeValidator.IsValid(nationalCode);
            if (!isValid)
                throw new InvalidNationalCodeException();
        }
    }
}