
namespace RpsGame.Core.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using RpsGame.Core.Weapons;

    public static class WeaponUtils
    {
        public static IEnumerable<BaseWeapon> GetAvailableWeapons()
        {
            return Assembly
                .GetAssembly(typeof(BaseWeapon))
                .GetTypes()
                .Where(type => type.IsClass && !type.IsAbstract && type.IsSubclassOf(typeof(BaseWeapon)))
                .Select(t => (BaseWeapon)Activator.CreateInstance(t));
        }
    }
}