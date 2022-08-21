using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Sample.Application.Exceptions;
using Sample.Application.Interfaces.Services;
using Sample.Test.Tools.Teachers;
using Sample.Tests.Unit.Infrastructures;
using SQLitePCL;
using Xunit;

namespace Sample.Tests.Unit.Teachers
{
    public class TeacherServiceTests : PersistentTest
    {
        private readonly ITeacherService _sut;

        public TeacherServiceTests()
        {
            _sut = TeacherFactory.CreateService(_dataContext);
        }

        [Fact]
        public async Task Add_adds_teacher_properly()
        {
            var dto = new AddTeacherDtoBuilder()
                .WithName("dummy-name")
                .WithNationalCode("2283876524")
                .WithPhoneNumber("9397777777")
                .Build();

            var teacherId = await _sut.Add(dto);

            var actualResult =
                _readDataContext.Teachers.Single(_ => _.Id == teacherId);
            actualResult.Name.Should().Be(dto.Name);
            actualResult.NationalCode.Should().Be(dto.NationalCode);
            actualResult.PhoneNumber.Should().Be(dto.PhoneNumber);
        }

        [Theory]
        [InlineData("93971368")]
        [InlineData("9893971368")]
        public async Task
            Add_throws_IncorrectPhoneNumberException_when_teacher_phone_number_is_incorrect(
                string invalidPhoneNumber)
        {
            var dto = new AddTeacherDtoBuilder()
                .WithPhoneNumber(invalidPhoneNumber)
                .Build();

            Func<Task> actualResult = () => _sut.Add(dto);

            await actualResult.Should()
                .ThrowExactlyAsync<IncorrectPhoneNumberException>();
        }

        [Fact]
        public void
            Add_throws_InvalidNationalCodeException_when_teacher_national_code_is_incorrect()
        {
            var dto = new AddTeacherDtoBuilder()
                .WithNationalCode("2283888888")
                .Build();

            Func<Task> actualResult = () => _sut.Add(dto);

            actualResult.Should()
                .ThrowExactlyAsync<InvalidNationalCodeException>();
        }
    }
}