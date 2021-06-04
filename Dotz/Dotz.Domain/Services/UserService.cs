﻿using Dotz.Domain.Entities;
using Dotz.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        public UserService(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }
        public Task CreateAddressAsync(string description)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(string email, string password)
        {
            var existingUser = await _userRepository.Find(email);

            ValidateUser(existingUser);

            var newUser = new User(email, GetHash(password));
            await _userRepository.AddAsync(newUser);
        }

        public async Task<string> Login(string email, string password)
        {
            var user = await _userRepository.Find(email, GetHash(password));
            if (user == null)
                throw new Exception("Senha incorreta ou usuário inexistente");

            return _tokenService.GenerateToken(user);
        }

        private static void ValidateUser(User existingUser)
        {
            if (existingUser != null)
                throw new ArgumentException("E-mail já cadastrado");
        }

        private string GetHash(string text)
        {
            byte[] data = Encoding.ASCII.GetBytes(text);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            return Encoding.ASCII.GetString(data);
        }
        public Task<IEnumerable<Order>> GetOrdersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserHistory>> GetUserHistoryAsync()
        {
            throw new NotImplementedException();
        }

        public async Task GivePoints(string email, int points)
        {
            var user = await _userRepository.Find(email);
            user.AddPoints(points);
            await _userRepository.Update(user);
        }
    }
}
