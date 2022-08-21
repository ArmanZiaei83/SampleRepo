using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Sample.Application.Contracts.Services;
using Sample.Test.Tools.Teachers;
using Sample.Tests.Unit.Infrastructures;
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
                .WithPhoneNumber("939999999")
                .Build();

            var teacherId = await _sut.Add(dto);

            var actualResult =
                _readDataContext.Teachers.Single(_ => _.Id == teacherId);
            actualResult.Name.Should().Be(dto.Name);
            actualResult.NationalCode.Should().Be(dto.NationalCode);
            actualResult.PhoneNumber.Should().Be(dto.PhoneNumber);
        }
    }
}