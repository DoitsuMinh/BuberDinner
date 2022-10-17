﻿using BuberDinner.Application.Common.Errors;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Entities;
using ErrorOr;

namespace BuberDinner.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
        {
            //1. Validate the user doesn't exist
            if (_userRepository.GetUserByEmail(email) is not null)
            {
                return Errors.User.DuplicateEmail;
            }

            //2. Create user (generate unique ID) & Persist to DB
            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };

            _userRepository.AddUser(user);
            //3. Create JWT Token


            var token = _jwtTokenGenerator.GenerateToken(user.Id, firstName, lastName);

            return new AuthenticationResult(
                user,
                token);
        }


        public AuthenticationResult Login(string email, string password)
        {
            //1. Validate if user exists
            if(_userRepository.GetUserByEmail(email) is not User user)
            {
                throw new Exception("Email not correct");
            }

            //2. Validate the password is correct
            if(user.Password != password)
            {
                throw new Exception("Password not correct");
            }

            //3. Create JWT token

            var token = _jwtTokenGenerator.GenerateToken(user.Id, user.FirstName, user.LastName);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}
