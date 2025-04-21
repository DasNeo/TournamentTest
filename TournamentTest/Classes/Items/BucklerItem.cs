using TournamentTest.Classes.Items.Interfaces;

namespace TournamentTest.Items;

public class BucklerItem : IDefensiveItem
{
    public string Name { get; set; } = "buckler";
    public int Uses { get; set; } = 3;
    public IItem.ItemType Type { get; set; } = IItem.ItemType.Buckler;
    public int Cooldown { get; set; } = 2;

    public int Use(IItem.ItemType attackerWeapon)
    {
        if (attackerWeapon != IItem.ItemType.Axe)
            return 0;
            
        Uses--;
        if (Uses <= 0)
            OnItemUsed?.Invoke(this, EventArgs.Empty);
        return 0;
    }

    public int Use()
    {
        throw new NotImplementedException();
    }

    public event EventHandler? OnItemUsed;

    public int Armor { get; set; }
    public bool BlockAllDamage { get; set; } = true;
    public int SelfDamageReduction { get; set; }
}