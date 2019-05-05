
namespace RpsGame.Core.Weapons
{
    public class Scissors : BaseWeapon, ICrushable
    {
        public override string Name => "Scissors";

        public override PowerType[] Powers => new PowerType[] { PowerType.Cut };
    }
}