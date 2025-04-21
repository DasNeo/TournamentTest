using TournamentTest.Classes.Items.Interfaces;

namespace TournamentTest.Classes.Items;

public class ArmorItem : IDefensiveItem
{
    public string Name { get; set; } = "armor";
    public int Uses { get; set; } = -1;
    public IItem.ItemType Type { get; set; } = IItem.ItemType.Armor;
    public int Cooldown { get; set; } = 0;
    public int Use(IItem.ItemType attackerWeapon, int incomingDamage) => Armor;
    public int Use()
    {
        throw new NotImplementedException();
    }

    public event EventHandler? OnItemBroken;
    public int Armor { get; set; } = 3;
    public bool BlockAllDamage { get; set; } = false;
    public int SelfDamageReduction { get; set; } = 1;
}