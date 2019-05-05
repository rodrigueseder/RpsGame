
namespace RpsGame.Core.Weapons
{
    public class Paper : BaseWeapon, ICuttable
    {
        public override string Name => "Paper";

        public override PowerType[] Powers => new PowerType[] { PowerType.Cover };
    }
}