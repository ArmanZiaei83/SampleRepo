using System.Threading.Tasks;
using FluentAssertions;
using Sample.Application.Interfaces.Services;
using Sample.Domain.Entities;
using Sample.Test.Tools.Students;
using Test.Specifications.Infrastructures;
using Test.Specifications.Infrastructures.Attributes;
using Xunit;

namespace Test.Specifications.Students.Delete
{
    [Scenario("Deleting a student")]
    public class DeleteStudentSuccessfully : TestProvider
    {
        private readonly IStudentService _sut;
        private Student _student;

        public DeleteStudentSuccessfully()
        {
            _sut = StudentFactory.CreateService(_dataContext);
        }

        [Given(
            " There is a student named 'Arman' with phone number '9397136812' " +
            " and national code '2833411839' in my students list ")]
        private void Given()
        {
            _student = new StudentBuilder()
                .WithName("Arman")
                .WithNationalCode("2833411839")
                .WithPhoneNumber("9397136812")
                .Build();
            Save(_student);
        }

        [When(
            " I delete a student named 'Arman' with phone number '9397136812' " +
            " and national code '2833411839' from my students list ")]
        private async Task When()
        {
            await _sut.DeleteById(_student.Id);
        }

        [Then(
            "There shouldn't be any student named 'Arman' with phone number '9397136812' " +
            " and national code '2833411839' in my teachers list ")]
        private void Then()
        {
            _readDataContext.Students.Should().NotContain(_ =>
                _.Id == _student.Id && 
                _.Name == _student.Name &&
                _.NationalCode == _student.NationalCode &&
                _.PhoneNumber == _student.PhoneNumber);
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