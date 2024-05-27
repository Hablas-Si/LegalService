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

        public AuctionRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> GetAllAuctionsAsync()
        {
            var response = await _httpClient.GetAsync($"/api/Auction/all");
            response.EnsureSuccessStatusCode();
            return response;
        }

        public async Task<HttpResponseMessage> GetAuctionAsync(Guid auctionId)
        {
            var response = await _httpClient.GetAsync($"/api/Auction/{auctionId}");
            response.EnsureSuccessStatusCode();
            return response;
        }
    }
}