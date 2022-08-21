using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Sample.Application.Exceptions;
using Sample.Application.Interfaces.Services;
using Sample.Test.Tools.Students;
using Sample.Tests.Unit.Infrastructures;
using Xunit;

namespace Sample.Tests.Unit.Students
{
    public class StudentServiceTests : PersistentTest
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
                .WithNationalCode("2283876524")
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
    }
}