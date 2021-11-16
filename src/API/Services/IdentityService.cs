using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using API.Contracts.Requests;
using API.Contracts.Responses;
using API.Dtos;
using API.Exceptions;
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

        public IdentityService(UserManager<User> userManager, DataContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        private static readonly Regex Regex = new ("@[a-z]*.[a-z]*");
        private async Task<string> GenerateUserNameAsync(string email)
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
        
        public async Task<AuthorizedResponse> RegisterAsync(RegisterRequest request)
        {
            if (await _context.Users.AnyAsync(user => user.Email == request.Email))
            {
                throw new BadRequestRestException("Invalid credentials");
            }
            
            User user = request.Adapt<User>();
            user.UserName = await GenerateUserNameAsync(request.Email);
            
            IdentityResult createNewUserResult = await _userManager.CreateAsync(user, request.Password);

            if (!createNewUserResult.Succeeded)
            {
                throw new BadRequestRestException("Invalid credentials");
            }

            await _userManager.AddToRoleAsync(user, Env.Roles.USER);

            return new AuthorizedResponse
            {
                User = user.Adapt<UserDto>()
            };
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
            
            return new AuthorizedResponse
            {
                User = user.Adapt<UserDto>()
            };
        }
    }
}