
namespace RpsGame.Api.Dto
{
    using System;

    public class MatchResult
    {
        public string Id { get; set; }
        public string Player1Id { get; set; }
        public string Player1Name { get; set; }
        public string Player1Weapon { get; set; }
        public string Player2Id { get; set; }
        public string Player2Name { get; set; }
        public string Player2Weapon { get; set; }
        public string ResultType { get; set; }
        public string WinnerId { get; set; }
        public DateTime Timestamp { get; set; }
    }
}