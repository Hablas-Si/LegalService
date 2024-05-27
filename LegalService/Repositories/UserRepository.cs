using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Repositories;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Respository
{
    public class UserRepository : IUserRepository
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserRepository(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<HttpResponseMessage> GetUserAsync(Guid userId)
        {
            var token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString();
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.Replace("Bearer ", ""));

            var response = await _httpClient.GetAsync($"/api/User/getuser/{userId}");
            response.EnsureSuccessStatusCode();
            return response;
        }
    }

}