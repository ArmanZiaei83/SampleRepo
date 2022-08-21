﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sample.Application.Contracts.Services;
using Sample.Application.DTOs;

namespace Sample.WebApi.Controllers.Teachers
{
    [ApiController]
    [Route("api/teachers")]
    public class TeacherController : Controller
    {
        private readonly ITeacherService _service;

        public TeacherController(ITeacherService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<int> Add(AddTeacherDto dto)
        {
            return await _service.Add(dto);
        }
    }
}