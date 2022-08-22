using Sample.Domain.Entities;

namespace Sample.Test.Tools.Students
{
    public class StudentBuilder
    {
        private readonly Student _student;

        public StudentBuilder()
        {
            _student = new Student();
        }

        public StudentBuilder WithName(string name)
        {
            _student.Name = name;
            return this;
        }

        public StudentBuilder WithNationalCode(string nationalCode)
        {
            _student.NationalCode = nationalCode;
            return this;
        }

        public StudentBuilder WithPhoneNumber(string phoneNumber)
        {
            _student.PhoneNumber = phoneNumber;
            return this;
        }

        public Student Build()
        {
            return _student;
        }
    }
}