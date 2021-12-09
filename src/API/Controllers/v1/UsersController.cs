﻿using System;
using System.Threading.Tasks;
using API.Controllers.Base;
using API.Services.v1;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.v1;

[ApiVersion("1.0")]
public class UsersController : ApiController
{
    private readonly UsersServiceV1 _usersService;

    public UsersController(UsersServiceV1 usersService)
    {
        _usersService = usersService;
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> Get(Guid userId)
    {
        return Ok(await _usersService.GetUserById(userId));
    }
}