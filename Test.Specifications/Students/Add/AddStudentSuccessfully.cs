using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Sample.Application.Interfaces.Services;
using Sample.Test.Tools.Students;
using Test.Specifications.Infrastructures;
using Test.Specifications.Infrastructures.Attributes;
using Xunit;

namespace Test.Specifications.Students.Add
{
    public class AddStudentSuccessfully : TestProvider
    {
        private readonly IStudentService _sut;
        private int _studentId;
 
        public AddStudentSuccessfully()
        {
            _sut = StudentFactory.CreateService(_dataContext);
        }

        [Given(" There isn't any student in my application ")]
        private void Given()
        {
        }

        [When(" I add a student named 'Ali' with phone number " +
              "'9177136812' & national code '2833411839' ")]
        private async Task When()
        {
            var dto = new AddStudentDtoBuilder()
                .WithName("Ali")
                .WithNationalCode("2833411839")
                .WithPhoneNumber("9177136812")
                .Build();

            _studentId = await _sut.Add(dto);
        }

        [Then(" There should be exactly one student named 'Ali' " +
              "with phone number '9177136812' & national code '2833411839' in my students list ")]
        private void Then()
        {
            _readDataContext.Students.Should().HaveCount(1);
            var actualResult =
                _readDataContext.Students.Single(_ => _.Id == _studentId);
            actualResult.Name.Should().Be("Ali");
            actualResult.NationalCode.Should().Be("2833411839");
            actualResult.PhoneNumber.Should().Be("9177136812");
        }

        [Fact]
        public void Run()
        {
            Runner.RunScenario(
                _ => Given(),
                _ => When().Wait(),
                _ => Then()
            );
        }
    }
}