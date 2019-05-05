
namespace RpsGame.Core
{
    using System;
    using System.Globalization;
    using RpsGame.Core.Weapons;

    public class Player : IEntity
    {
        public string Id { get; } = $"Player-{Guid.NewGuid().ToString("N", CultureInfo.InvariantCulture)}";
        public string Name { get; private set; }
        public BaseWeapon Weapon { get; private set; }

        public Player(string name, BaseWeapon weapon)
        {
            this.Name = name;
            this.Weapon = weapon;
        }
    }
}
