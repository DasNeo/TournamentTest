using TournamentTest.Classes.Items.Interfaces;

namespace TournamentTest.Items;

public class SwordItem : IOffensiveItem
{
    public string Name { get; set; } = "sword";
    public int Uses { get; set; } = -1;
    public IItem.ItemType Type { get; set; } = IItem.ItemType.Sword;
    public int Cooldown { get; set; } = 0;
    public int Use() => Damage;
    public event EventHandler? OnItemUsed;
    public int Damage { get; set; } = 5;
}