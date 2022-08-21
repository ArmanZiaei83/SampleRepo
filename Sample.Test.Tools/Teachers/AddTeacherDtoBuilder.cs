using Sample.Application.DTOs;

namespace Sample.Test.Tools.Teachers
{
    public class AddTeacherDtoBuilder
    {
        private readonly AddTeacherDto _dto;

        public AddTeacherDtoBuilder()
        {
            _dto = new AddTeacherDto
            {
                Name = "dummy-name",
                PhoneNumber = "9399999999",
                NationalCode = "2833411839"
            };
        }

        public AddTeacherDtoBuilder WithName(string name)
        {
            _dto.Name = name;
            return this;
        }

        public AddTeacherDtoBuilder WithNationalCode(string nationalCode)
        {
            _dto.NationalCode = nationalCode;
            return this;
        }

        public AddTeacherDtoBuilder WithPhoneNumber(string phoneNumber)
        {
            _dto.PhoneNumber = phoneNumber;
            return this;
        }

        public AddTeacherDto Build()
        {
            return _dto;
        }
    }
}