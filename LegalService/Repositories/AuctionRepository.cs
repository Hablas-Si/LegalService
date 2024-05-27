using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Repositories;

namespace Respository
{
    public class AuctionRepository : IAuctionRespository
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuctionRepository(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<HttpResponseMessage> GetAllAuctionsAsync()
        {
            // gemmer token til kald på auctionservice (kræver rolle på auctionservice)
            var token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString();
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.Replace("Bearer ", ""));

            var response = await _httpClient.GetAsync($"/api/Auction/all");
            response.EnsureSuccessStatusCode();
            return response;
        }

        public async Task<HttpResponseMessage> GetAuctionAsync(Guid auctionId)
        {
            // gemmer token til kald på auctionservice (kræver rolle på auctionservice)
            var token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString();
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.Replace("Bearer ", ""));

            var response = await _httpClient.GetAsync($"/api/Auction/{auctionId}");
            response.EnsureSuccessStatusCode();
            return response;
        }
    }
}