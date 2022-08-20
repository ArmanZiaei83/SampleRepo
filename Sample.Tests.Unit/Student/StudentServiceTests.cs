using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Sample.Application.Contracts.Services;
using Sample.Test.Tools.Student;
using Sample.Tests.Unit.Infrastructures;
using Xunit;

namespace Sample.Tests.Unit.Student
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
    }
}