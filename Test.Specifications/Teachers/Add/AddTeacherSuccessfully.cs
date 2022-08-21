using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Sample.Application.Interfaces.Services;
using Sample.Test.Tools.Teachers;
using Test.Specifications.Infrastructures;
using Test.Specifications.Infrastructures.Attributes;
using Xunit;

namespace Test.Specifications.Teachers.Add
{
    public class AddTeacherSuccessfully : TestProvider
    {
        private readonly ITeacherService _sut;
        private int _teacherId;

        public AddTeacherSuccessfully()
        {
            _sut = TeacherFactory.CreateService(_dataContext);
        }

        [Given(" There isn't any teacher in my application. ")]
        private void Given()
        {
        }

        [When(" I add a teacher named 'Ali' with phone number " +
              " '9177136812' & national code '2833411839' ")]
        private async Task When()
        {
            var dto = new AddTeacherDtoBuilder()
                .WithName("Ali")
                .WithNationalCode("2833411839")
                .WithPhoneNumber("9177136812")
                .Build();

            _teacherId = await _sut.Add(dto);
        }

        [Then("There should be exactly one teacher named 'Ali' with " +
              " phone number '9177136812' & national code '2833411839' ")]
        private void Then()
        {
            _readDataContext.Teachers.Should().HaveCount(1);
            var actualResult =
                _readDataContext.Teachers.Single(_ => _.Id == _teacherId);
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