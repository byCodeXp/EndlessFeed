using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using API.Contracts.Requests;
using API.Contracts.Responses;
using API.Dtos;
using DAL;
using DAL.Entities;
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
                return null;
            }
            
            string userName = await GenerateUserNameAsync(request.Email);

            var user = new User
            {
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                UserName = userName
            };

            IdentityResult createResult = await _userManager.CreateAsync(user, request.Password);

            if (!createResult.Succeeded)
            {
                return null;
            }

            await _userManager.AddToRoleAsync(user, Env.Roles.USER);

            return new AuthorizedResponse
            {
                User = new UserDto
                {
                    Id = user.Id,
                    Name = user.Name,
                    Surname = user.Surname,
                    Username = user.UserName,
                }
            };
        }

        public async Task<AuthorizedResponse> LoginAsync(LoginRequest request)
        {
            User user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                return null;
            }

            bool checkPassword = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!checkPassword)
            {
                return null;
            }
            
            return new AuthorizedResponse
            {
                User = new UserDto
                {
                    Id = user.Id,
                    Name = user.Name,
                    Photo = user.Photo,
                    Surname = user.Surname,
                    Username = user.UserName,
                }
            };
        }
    }
}