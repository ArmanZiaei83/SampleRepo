using System.Threading.Tasks;
using Sample.Application.DTOs;
using Sample.Application.Exceptions;
using Sample.Application.Interfaces;
using Sample.Application.Interfaces.Repositories;
using Sample.Application.Interfaces.Services;
using Sample.Domain.Entities;
using Sample.Infrastructure.Shared;

namespace Sample.Application.Students
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public StudentService(
            IUnitOfWork unitOfWork,
            IStudentRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<int> Add(AddStudentDto dto)
        {
            ThrowExceptionWhenPhoneNumberIsIncorrect(dto.PhoneNumber);
            ThrowExceptionWhenNationalCodeIsIncorrect(dto.NationalCode);
            var student = new Student
            {
                Name = dto.Name,
                NationalCode = dto.NationalCode,
                PhoneNumber = dto.PhoneNumber
            };

            _repository.Add(student);
            await _unitOfWork.Complete();

            return student.Id;
        }

        public async Task DeleteById(int id)
        {
            await ThrowExceptionWhenStudentHasNotFound(id);
            var student = await _repository.Find(id);
            _repository.DeleteById(student);
            await _unitOfWork.Complete();
        }

        private async Task ThrowExceptionWhenStudentHasNotFound(int studentId)
        {
            var exists = await _repository.Exists(studentId);
            if (!exists)
                throw new StudentNotFoundException();
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