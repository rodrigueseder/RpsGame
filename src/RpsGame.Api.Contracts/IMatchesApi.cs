
namespace RpsGame.Api.Contracts
{
    using System;
    using Refit;
    using RpsGame.Api.Contracts.Dto;

    /// <summary>
    /// Provide methods to handle matches
    /// </summary>
    public interface IMatchesApi
    {
        /// <summary>
        /// Runs a single player match, with provided player against an auto created (AI) player
        /// </summary>
        [Post("api/matches/singlePlayer")]
        MatchResult RunSinglePlayerMatch([Body] SinglePlayerMatchRequest request);
    }
}
