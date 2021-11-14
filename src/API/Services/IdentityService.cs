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

        private async Task<string> GenerateUserNameAsync(string email)
        {
            string symbols = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz";
            
            string pattern = "@[a-z]*.[a-z]*";
            string userName = Regex.Replace(email, pattern, "");

            var rand = new Random(DateTime.Now.Millisecond);
            
            while (true)
            {
                if (!await _context.Users.AnyAsync(user => user.UserName == userName))
                {
                    break;
                }
                
                int index = rand.Next(symbols.Length);
                userName += symbols[index];
            }
            
            return userName;
        }
        
        public async Task<AuthorizedResponse> RegisterAsync(RegisterRequest request)
        {
            if (await _context.Users.AnyAsync(user => user.Email == request.Email))
            {
                throw new BadRequestRestException("Invalid credentials");
            }
            
            User user = request.Adapt<User>();
            user.UserName = await GenerateUserNameAsync(request.Email);
            
            IdentityResult createResult = await _userManager.CreateAsync(user, request.Password);

            if (!createResult.Succeeded)
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

            if (user == null)
            {
                throw new BadRequestRestException("Invalid credentials");
            }

            bool checkPassword = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!checkPassword)
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