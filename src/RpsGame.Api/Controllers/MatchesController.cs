
namespace RpsGame.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using RpsGame.Api.Dto;
    using RpsGame.Core;
    using RpsGame.Core.Utils;
    using RpsGame.Core.Weapons;

    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private static readonly Random random = new Random();
        private readonly Dictionary<string, BaseWeapon> availableWeapons;

        public MatchesController()
        {
            availableWeapons = WeaponUtils.GetAvailableWeapons().ToDictionary(w => w.Name, w => w);
        }

        [HttpPost("singlePlayer")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(MatchResult), (int)HttpStatusCode.OK)]
        public IActionResult RunSinglePlayerMatch([FromBody] SinglePlayerMatchRequest request)
        {
            if (!availableWeapons.TryGetValue(request.Player1Weapon, out var player1Weapon))
            {
                return this.BadRequest($"Invalid weapon '{request.Player1Weapon}'");
            }

            var player1 = new Player(request.Player1Name, player1Weapon);
            var player2 = this.GetAIPlayer();

            var match = new Match(player1, player2);
            match.TryRun();

            return this.Ok(this.Map(match));
        }

        private Player GetAIPlayer()
        {
            var player2Name = "AI";
            var player2Weapon = availableWeapons.ElementAt(random.Next(0, availableWeapons.Count - 1)).Value;
            return new Player(player2Name, player2Weapon);
        }

        private MatchResult Map(Match match)
        {
            return new MatchResult
            {
                Id = match.Id,
                Player1Id = match.Player1?.Id,
                Player1Name = match.Player1?.Name,
                Player1Weapon = match.Player1?.Weapon?.Name,
                Player2Id = match.Player2?.Id,
                Player2Name = match.Player2?.Name,
                Player2Weapon = match.Player2?.Weapon?.Name,
                ResultType = match.Result.ToString(),
                WinnerId = match.WinnerId,
                Timestamp = match.Timestamp
            };
        }
    }
}
