
namespace RpsGame.Core.Extensions
{
    using System;
    using RpsGame.Core.Weapons;

    internal static class WeaponExtensions
    {
        internal static bool Beats(this BaseWeapon weapon, BaseWeapon opponentWeapon, Func<BaseWeapon, BaseWeapon, bool> check)
        {
            return check(weapon, opponentWeapon);
        }
    }
}