using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace Repositories
{
    public interface IAuctionRespository
    {
        Task<HttpResponseMessage> GetAllAuctionsAsync();
        Task<HttpResponseMessage> GetAuctionAsync(Guid auctionId);

    }
}