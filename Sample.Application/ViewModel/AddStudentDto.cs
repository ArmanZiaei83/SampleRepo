using System.ComponentModel.DataAnnotations;

namespace Sample.Application.ViewModel
{
    public class AddStudentDto
    {
        [Required] public string Name { get; set; }

        [Required] public string PhoneNumber { get; set; }

        [Required] public string NationalCode { get; set; }
    }
}