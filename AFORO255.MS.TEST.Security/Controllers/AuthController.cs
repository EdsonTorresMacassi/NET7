﻿using Aforo255.Cross.Token.Src;
using AFORO255.MS.TEST.Security.etm.DTOs;
using AFORO255.MS.TEST.Security.etm.Services;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AFORO255.MS.TEST.Security.etm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAccessService _accessService;
        private readonly JwtOptions _jwtOption;

        public AuthController(IAccessService accessService, IOptionsSnapshot<JwtOptions> jwtOption)
        {
            _accessService = accessService;
            _jwtOption = jwtOption.Value;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_accessService.GetAll());
        }

        [HttpPost]
        public IActionResult Post([FromBody] AuthRequest request)
        {
            if (!_accessService.Validate(request.UserName, request.Password))
            {
                return Unauthorized();
            }

            string token = JwtToken.Create(_jwtOption);
            Response.Headers.Add("access-control-expose-headers", "Authorization");
            Response.Headers.Add("Authorization", token);
            return Ok(new AuthResponse(token, "1h"));
        }
    }
}
