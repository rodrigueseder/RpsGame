
namespace RpsGame.Core.Weapons
{
    public class Rock : BaseWeapon, ICoverable
    {
        public override string Name => "Rock";

        public override PowerType[] Powers => new PowerType[] { PowerType.Crush };
    }
}