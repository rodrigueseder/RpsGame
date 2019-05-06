
namespace RpsGame.Core.Tests.Unit
{
    using System;
    using System.Collections.Generic;
    using RpsGame.Core.Weapons;
    using Xunit;

    public class MatchTests
    {
        public static IEnumerable<object[]> DataForShouldDrawWhenNoPlayersOrWeapons()
        {
            yield return new object[] { null, null };

            yield return new object[] { new Player("player1", null), null };
            yield return new object[] { null, new Player("player2", null) };

            yield return new object[] { new Player("player1", null), new Player("player2", null) };

            yield return new object[] { new Player("player1", new Rock()), new Player("player2", null) };
            yield return new object[] { new Player("player1", null), new Player("player2", new Rock()) };
        }

        [Theory]
        [MemberData(nameof(DataForShouldDrawWhenNoPlayersOrWeapons))]
        public void ShouldDrawWhenNoPlayersOrWeapons(Player player1, Player player2)
        {
            // Arrange
            var match = new Match(player1, player2);

            // Act
            var matchRunResult = match.TryRun();

            // Assert
            Assert.False(matchRunResult);
            Assert.Equal(MatchResultType.Draw, match.Result);
            Assert.Equal(string.Empty, match.WinnerId);
        }

        public static IEnumerable<object[]> DataForShouldTieWhenSameWeapons()
        {
            yield return new object[] { new Player("player1", new Rock()), new Player("player2", new Rock()) };
            yield return new object[] { new Player("player1", new Paper()), new Player("player2", new Paper()) };
            yield return new object[] { new Player("player1", new Scissors()), new Player("player2", new Scissors()) };
        }

        [Theory]
        [MemberData(nameof(DataForShouldTieWhenSameWeapons))]
        public void ShouldTieWhenSameWeapons(Player player1, Player player2)
        {
            // Arrange
            var match = new Match(player1, player2);

            // Act
            var matchRunResult = match.TryRun();

            // Assert
            Assert.True(matchRunResult);
            Assert.Equal(MatchResultType.Tie, match.Result);
            Assert.Equal(string.Empty, match.WinnerId);
        }

        public static IEnumerable<object[]> DataForShouldReturnPlayer1AsWinnerWhenBetterWeapon()
        {
            yield return new object[] { new Player("player1", new Rock()), new Player("player2", new Scissors()) };
            yield return new object[] { new Player("player1", new Paper()), new Player("player2", new Rock()) };
            yield return new object[] { new Player("player1", new Scissors()), new Player("player2", new Paper()) };
        }

        [Theory]
        [MemberData(nameof(DataForShouldReturnPlayer1AsWinnerWhenBetterWeapon))]
        public void ShouldReturnPlayer1AsWinnerWhenBetterWeapon(Player player1, Player player2)
        {
            // Arrange
            var match = new Match(player1, player2);

            // Act
            var matchRunResult = match.TryRun();

            // Assert
            Assert.True(matchRunResult);
            Assert.Equal(MatchResultType.OneWinner, match.Result);
            Assert.Equal(player1.Id, match.WinnerId);
        }

        public static IEnumerable<object[]> DataForShouldReturnPlayer2AsWinnerWhenBetterWeapon()
        {
            yield return new object[] { new Player("player1", new Scissors()), new Player("player2", new Rock()) };
            yield return new object[] { new Player("player1", new Rock()), new Player("player2", new Paper()) };
            yield return new object[] { new Player("player1", new Paper()), new Player("player2", new Scissors()) };
        }

        [Theory]
        [MemberData(nameof(DataForShouldReturnPlayer2AsWinnerWhenBetterWeapon))]
        public void ShouldReturnPlayer2AsWinnerWhenBetterWeapon(Player player1, Player player2)
        {
            // Arrange
            var match = new Match(player1, player2);

            // Act
            var matchRunResult = match.TryRun();

            // Assert
            Assert.True(matchRunResult);
            Assert.Equal(MatchResultType.OneWinner, match.Result);
            Assert.Equal(player2.Id, match.WinnerId);
        }
    }
}
