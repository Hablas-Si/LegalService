using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Repositories;

namespace Respository
{
    public class UserRepository : IUserRepository
    {
        private readonly HttpClient _httpClient;

        public UserRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> GetUserAsync(Guid userId)
        {
            var response = await _httpClient.GetAsync($"/api/User/getuser/{userId}");
            response.EnsureSuccessStatusCode();
            return response;
        }
    }

}