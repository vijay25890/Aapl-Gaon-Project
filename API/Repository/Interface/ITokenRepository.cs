﻿using Microsoft.AspNetCore.Identity;

namespace API.Repository.Interface
{
    public interface ITokenRepository
    {
        string CreateJwtToken(IdentityUser user, List<string> roles);
    }
}
