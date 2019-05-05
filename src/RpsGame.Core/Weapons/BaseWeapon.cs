
namespace RpsGame.Core.Weapons
{
    using System;
    using System.Linq;

    public abstract class BaseWeapon
    {
        public abstract string Name { get; }

        public abstract PowerType[] Powers { get; }

        public override bool Equals(object value)
        {
            return Equals(value as BaseWeapon);
        }

        public bool Equals(BaseWeapon otherWeapon)
        {
            if (Object.ReferenceEquals(null, otherWeapon)) return false;
            if (Object.ReferenceEquals(this, otherWeapon)) return true;

            return String.Equals(Name, otherWeapon.Name);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                const int HashingBase = (int)2166136261;
                const int HashingMultiplier = 16777619;

                int hash = HashingBase;
                hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, Name) ? Name.GetHashCode() : 0);
                hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, Powers) ? Powers.GetHashCode() : 0);
                return hash;
            }
        }

        public static bool operator ==(BaseWeapon weapon1, BaseWeapon weapon2)
        {
            if (Object.ReferenceEquals(weapon1, weapon2)) return true;
            if (Object.ReferenceEquals(null, weapon1)) return false;
            return (weapon1.Equals(weapon2));
        }

        public static bool operator !=(BaseWeapon weapon1, BaseWeapon weapon2)
        {
            return !(weapon1 == weapon2);
        }
    }
}