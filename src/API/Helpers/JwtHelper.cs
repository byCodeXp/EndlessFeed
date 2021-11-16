﻿using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace API.Helpers
{
    public class JwtHelper
    {
        private const string SecurityAlgorithm = SecurityAlgorithms.HmacSha512Signature;

        private readonly SigningCredentials _signingCredentials;

        public JwtHelper(IConfiguration configuration)
        {
            string secretText = configuration["Jwt:Secret"];
            byte[] secret = Encoding.ASCII.GetBytes(secretText);

            var securityKey = new SymmetricSecurityKey(secret);

            _signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithm);
        }

        private static readonly JwtSecurityTokenHandler JwtTokenHandler = new();

        public string GenerateToken(string userId, string userRoles, TimeSpan duration)
        {
            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new(Env.IdentityClaims.ID, userId, ClaimValueTypes.String),
                    new(Env.IdentityClaims.ROLES, userRoles, ClaimValueTypes.String)
                }),
                Expires = DateTime.UtcNow.Add(duration),
                SigningCredentials = _signingCredentials
            };

            var token = JwtTokenHandler.CreateToken(descriptor);

            return JwtTokenHandler.WriteToken(token);
        }
    }
}