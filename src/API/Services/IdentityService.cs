using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using API.Contracts.Requests;
using API.Contracts.Responses;
using API.Dtos;
using API.Exceptions;
using API.Helpers;
using DAL;
using DAL.Entities;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class IdentityService
    {
        private readonly UserManager<User> _userManager;
        private readonly DataContext _context;
        private readonly JwtHelper _jwtHelper;

        public IdentityService(UserManager<User> userManager, DataContext context, JwtHelper jwtHelper)
        {
            _userManager = userManager;
            _context = context;
            _jwtHelper = jwtHelper;
        }

        public async Task<AuthorizedResponse> RegisterAsync(RegisterRequest request)
        {
            if (await _context.Users.AnyAsync(user => user.Email == request.Email))
            {
                throw new BadRequestRestException("Invalid credentials");
            }
            
            User user = request.Adapt<User>();
            user.UserName = await GenerateUniqueUserNameAsync(request.Email);
            
            IdentityResult createNewUserResult = await _userManager.CreateAsync(user, request.Password);

            if (!createNewUserResult.Succeeded)
            {
                throw new BadRequestRestException("Invalid credentials");
            }

            await _userManager.AddToRoleAsync(user, Env.Roles.USER);

            return await GenerateAuthorizedResponse(user, Env.TokenExpirationTime.OneDay);
        }

        public async Task<AuthorizedResponse> LoginAsync(LoginRequest request)
        {
            User user = await _userManager.FindByEmailAsync(request.Email);

            if (user is null)
            {
                throw new BadRequestRestException("Invalid credentials");
            }

            bool passwordValid = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!passwordValid)
            {
                throw new BadRequestRestException("Invalid credentials");
            }

            TimeSpan tokenDuration = Env.TokenExpirationTime.OneDay;

            if (request.Remember)
            {
                tokenDuration = Env.TokenExpirationTime.SevenDays;
            }
            
            return await GenerateAuthorizedResponse(user, tokenDuration);
        }

        public async Task<UserDto> GetUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user is null)
            {
                throw new BadRequestRestException("User was not found");
            }

            return user.Adapt<UserDto>();
        }

        private async Task<AuthorizedResponse> GenerateAuthorizedResponse(User user, TimeSpan tokenLifetime)
        {
            string roles = string.Join(",", await _userManager.GetRolesAsync(user));

            string token = _jwtHelper.GenerateToken(user.Id.ToString(), roles, tokenLifetime);
            
            return new AuthorizedResponse
            {
                Token = token,
                User = user.Adapt<UserDto>()
            };
        }
        
        private static readonly Regex Regex = new ("@[a-z]*.[a-z]*");
        
        private async Task<string> GenerateUniqueUserNameAsync(string email)
        {
            const string symbols = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz";

            string newUserName = Regex.Replace(email, "");

            var rand = new Random(DateTime.Now.Millisecond);
            
            while (true)
            {
                if (!await _context.Users.AnyAsync(user => user.UserName == newUserName))
                {
                    break;
                }
                
                int index = rand.Next(symbols.Length);
                newUserName += symbols[index];
            }
            
            return newUserName;
        }
    }
}