using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Models;
using Repositories;
using Amazon.Runtime.SharedInterfaces;
using VaultSharp;
using VaultSharp.V1.AuthMethods.Token;
using VaultSharp.V1.AuthMethods;
using VaultSharp.V1.Commons;
using System.Net.Http.Formatting;


namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LegalController : ControllerBase
    {
        private readonly ILogger<LegalController> _logger;
        private readonly IConfiguration _config;
        private readonly IVaultService _vaultService;
        private readonly IUserRepository _UserService;
        private readonly IAuctionRespository _AuctionService;
        private readonly HttpClient _httpClient;

        public LegalController(ILogger<LegalController> logger, IConfiguration config, IVaultService vaultService, IUserRepository userRepository, IAuctionRespository auctionRespository, HttpClient httpClient)
        {
            _config = config;
            _logger = logger;
            _vaultService = vaultService;
            _UserService = userRepository;
            _AuctionService = auctionRespository;
            _httpClient = httpClient;
        }

        [HttpGet("users/{userId}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUser(Guid userId)
        {
            var user = await _UserService.GetUserAsync(userId);

            if (user == null)
            {
                return NotFound(new { error = "User not found" });
            }

            return Ok(user);
        }

        [HttpGet("auctions"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllAuctions()
        {
            var auctions = await _AuctionService.GetAllAuctionsAsync();

            if (auctions == null)
            {
                return NotFound(new { error = "Auctions not found" });
            }

            return Ok(auctions);
        }

        //Til test
        [HttpGet("authorized"), Authorize(Roles = "Admin")]
        public IActionResult Authorized()
        {

            // Hvis brugeren har en gyldig JWT-token og rollen "Admin", vil denne metode blive udført
            return Ok("You are authorized to access this resource.");
        }


    }
}