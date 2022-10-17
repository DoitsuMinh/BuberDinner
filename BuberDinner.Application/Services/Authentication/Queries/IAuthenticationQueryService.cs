﻿using BuberDinner.Contracts.Authentication;
using ErrorOr;

namespace BuberDinner.Application.Services.Authentication.Queries
{
    public interface IAuthenticationQueryService
    {
        ErrorOr<AuthenticationResult> Login(string email, string password);
    }
}