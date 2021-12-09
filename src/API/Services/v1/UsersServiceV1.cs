using System;
using System.Threading.Tasks;
using API.Dtos;
using API.Exceptions;
using API.Services.Base;
using DAL;
using DAL.Entities;
using Mapster;

namespace API.Services.v1;

public class UsersServiceV1 : Service
{
    public UsersServiceV1(DataContext context)
    {
        Context = context;
    }

    public async Task<UserDto> GetUserById(Guid userId)
    {
        var user = await Context.FindAsync<User>(userId);

        if (user is null)
        {
            throw new BadRequestRestException("User does not exists");
        }

        return user.Adapt<UserDto>();
    }
}