
namespace RpsGame.Core
{
    using System;
    using System.Globalization;
    using System.Linq;
    using RpsGame.Core.Extensions;
    using RpsGame.Core.Weapons;

    public class Match : IAggregate
    {
        public string Id { get; } = $"Match-{Guid.NewGuid().ToString("N", CultureInfo.InvariantCulture)}";
        public Player Player1 { get; private set; }
        public Player Player2 { get; private set; }
        public MatchResult Result { get; private set; }
        public string WinnerId { get; private set; }
        public DateTime Timestamp { get; private set; }

        public Match(Player player1, Player player2)
        {
            this.Player1 = player1;
            this.Player2 = player2;
        }

        public bool TryRun()
        {
            this.Timestamp = DateTime.UtcNow;

            if (this.Player1?.Weapon == null || this.Player2?.Weapon == null)
            {
                this.Result = MatchResult.Draw;
                this.WinnerId = string.Empty;
                return false;
            }

            if (this.Player1.Weapon == this.Player2.Weapon)
            {
                this.Result = MatchResult.Tie;
                this.WinnerId = string.Empty;
                return true;
            }

            if (this.Player1.Weapon.Beats(this.Player2.Weapon, this.CheckAgainstOpponent))
            {
                this.Result = MatchResult.OneWinner;
                this.WinnerId = this.Player1.Id;
                return true;
            }

            if (this.Player2.Weapon.Beats(this.Player1.Weapon, this.CheckAgainstOpponent))
            {
                this.Result = MatchResult.OneWinner;
                this.WinnerId = this.Player2.Id;
                return true;
            }

            return false;
        }

        internal bool CheckAgainstOpponent(BaseWeapon weapon, BaseWeapon opponentWeapon)
        {
            if (weapon.Powers.Contains(PowerType.Cover) && opponentWeapon is ICoverable)
                return true;

            if (weapon.Powers.Contains(PowerType.Crush) && opponentWeapon is ICrushable)
                return true;

            if (weapon.Powers.Contains(PowerType.Cut) && opponentWeapon is ICuttable)
                return true;

            return false;
        }
    }
}