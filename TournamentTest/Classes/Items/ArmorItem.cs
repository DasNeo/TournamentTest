using TournamentTest.Classes.Items.Interfaces;

namespace TournamentTest.Items;

public class ArmorItem : IDefensiveItem
{
    public string Name { get; set; } = "armor";
    public int Uses { get; set; } = -1;
    public IItem.ItemType Type { get; set; } = IItem.ItemType.Armor;
    public int Use() => Armor;
    public event EventHandler? OnItemUsed;
    public int Armor { get; set; } = 3;
    public bool BlockAllDamage { get; set; } = false;
    public int SelfDamageReduction { get; set; } = 1;
}