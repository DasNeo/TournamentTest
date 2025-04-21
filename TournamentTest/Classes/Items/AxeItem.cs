using TournamentTest.Classes.Items.Interfaces;

namespace TournamentTest.Items;

public class AxeItem : IOffensiveItem
{
    public string Name { get; set; } = "axe";
    public int Uses { get; set; } = -1;
    public IItem.ItemType Type { get; set; } = IItem.ItemType.Axe;
    public int Cooldown { get; set; } = 0;
    public int Use() => Damage;
    public event EventHandler? OnItemBroken;
    public int Damage { get; set; } = 6;
}