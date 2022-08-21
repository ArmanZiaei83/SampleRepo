using Sample.Application.DTOs;

namespace Sample.Test.Tools.Students
{
    public class AddStudentDtoBuilder
    {
        private readonly AddStudentDto _dto;

        public AddStudentDtoBuilder()
        {
            _dto = new AddStudentDto
            {
                Name = "dummy-name",
                PhoneNumber = "9399999999",
                NationalCode = "2833411839"
            };
        }

        public AddStudentDtoBuilder WithName(string name)
        {
            _dto.Name = name;
            return this;
        }

        public AddStudentDtoBuilder WithNationalCode(string nationalCode)
        {
            _dto.NationalCode = nationalCode;
            return this;
        }

        public AddStudentDtoBuilder WithPhoneNumber(string phoneNumber)
        {
            _dto.PhoneNumber = phoneNumber;
            return this;
        }

        public AddStudentDto Build()
        {
            return _dto;
        }
    }
}