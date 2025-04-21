using System.Diagnostics;
using TournamentTest.Classes.Items.Interfaces;

namespace TournamentTest.Items;

public class BucklerItem : IDefensiveItem
{
    public string Name { get; set; } = "buckler";
    public int Uses { get; set; } = 3;
    public IItem.ItemType Type { get; set; } = IItem.ItemType.Buckler;
    public int Cooldown { get; set; } = 2;

    private int _useCounter = 0;

    public int Use(IItem.ItemType attackerWeapon, int incomingDamage)
    {
        _useCounter++;
        if ((_useCounter - 1) % Cooldown != 0)
        {
            return 0; // Item is on cooldown
        }
        
        if (attackerWeapon != IItem.ItemType.Axe)
            return incomingDamage; // Negate all incoming damage
        
        Uses--;
        if(Uses <= 0)
            OnItemBroken?.Invoke(this, EventArgs.Empty);
        
        return incomingDamage; // Negate all incoming damage
    }

    public int Use()
    {
        throw new NotImplementedException();
    }

    public event EventHandler? OnItemBroken;

    public int Armor { get; set; }
    public bool BlockAllDamage { get; set; } = true;
    public int SelfDamageReduction { get; set; }
}