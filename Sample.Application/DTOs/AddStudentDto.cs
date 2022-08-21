﻿using System.ComponentModel.DataAnnotations;

namespace Sample.Application.DTOs
{
    public class AddStudentDto
    {
        [Required] public string Name { get; set; }

        [Required] public string PhoneNumber { get; set; }

        [Required] public string NationalCode { get; set; }
    }
}