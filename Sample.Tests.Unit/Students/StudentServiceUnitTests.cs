using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Sample.Application.Exceptions;
using Sample.Application.Interfaces.Services;
using Sample.Domain.Entities;
using Sample.Test.Tools.Students;
using Sample.Tests.Unit.Infrastructures;
using Xunit;

namespace Sample.Tests.Unit.Students
{
    public class StudentServiceTests : TestProvider
    {
        private readonly IStudentService _sut;

        public StudentServiceTests()
        {
            _sut = StudentFactory.CreateService(_dataContext);
        }

        [Fact]
        public async Task Add_adds_a_student_properly()
        {
            var dto = new AddStudentDtoBuilder()
                .WithName("dummy-name")
                .WithNationalCode("2833411839")
                .WithPhoneNumber("09397133333")
                .Build();

            var studentId = await _sut.Add(dto);

            var actualResult =
                _readDataContext.Students.Single(_ => _.Id == studentId);
            actualResult.Name.Should().Be(dto.Name);
            actualResult.NationalCode.Should().Be(dto.NationalCode);
            actualResult.PhoneNumber.Should().Be(dto.PhoneNumber);
        }

        [Theory]
        [InlineData("+9891736812")]
        public async Task
            Add_throws_IncorrectPhoneNumberException_when_student_phone_number_is_incorrect(
                string invalidPhoneNumber)
        {
            var dto = new AddStudentDtoBuilder()
                .WithPhoneNumber(invalidPhoneNumber)
                .Build();

            Func<Task> actualResult = () => _sut.Add(dto);

            await actualResult.Should()
                .ThrowExactlyAsync<IncorrectPhoneNumberException>();
        }

        [Fact]
        public void
            Add_throws_InvalidNationalCodeException_when_student_national_code_is_invalid()
        {
            var dto = new AddStudentDtoBuilder()
                .WithNationalCode("2283888888")
                .Build();

            Func<Task> actualResult = () => _sut.Add(dto);

            actualResult.Should()
                .ThrowExactlyAsync<InvalidNationalCodeException>();
        }

        [Fact]
        public void DeleteById_deletes_a_student_by_id_properly()
        {
            var studentId = CreateStudent();

            _sut.DeleteById(studentId);

            _readDataContext.Students.Should().HaveCount(0)
                .And.NotContain(_ => _.Id == studentId);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public async Task
            Delete_throws_StudentNotFoundException_when_student_has_not_found(
                int invalidStudentId)
        {
            Func<Task> actualResult = () => _sut.DeleteById(invalidStudentId);

            await actualResult.Should()
                .ThrowExactlyAsync<StudentNotFoundException>();
        }

        private int CreateStudent()
        {
            var student = new StudentBuilder()
                .WithName("dummy-name")
                .WithPhoneNumber("dummy-phone-number")
                .WithNationalCode("dummy-national-code")
                .Build();
            Save(student);
            return student.Id;
        }
    }
}