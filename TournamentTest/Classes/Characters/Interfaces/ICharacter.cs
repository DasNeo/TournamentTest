using System.Diagnostics;
using TournamentTest.Classes.Items.Interfaces;
using TournamentTest.Items;
using TournamentTest.Utils;

namespace TournamentTest.Characters.Interfaces;

public interface ICharacter
{
    public int Damage { get; set; }
    public int Health { get; set; }
    List<IItem> EquippedItems { get; set; }
    
    public void Engage(ICharacter other)
    {
        while (this.HitPoints() > 0 && other.HitPoints() > 0)
        {
            var weapon =
                EquippedItems.Select(r => r as IOffensiveItem)
                    .FirstOrDefault();
            var otherWeapon = 
                other.EquippedItems.Select(r => r as IOffensiveItem)
                    .FirstOrDefault();
            // Assume that you can only equip one weapon and always has one equipped.
            if (weapon is null || otherWeapon is null)
                return;
            
            other.TakeDamage(weapon.Use());
            TakeDamage(otherWeapon.Use());
        }
    }

    public int HitPoints(int reduction = 0)
    {
        if (reduction != 0)
            Health = reduction;
        
        return Health;
    }

    internal ICharacter EquipItem(string itemName)
    {
        IItem newItem;
        switch (itemName)
        {
            case "axe":
                newItem = new AxeItem();
                break;
            case "buckler":
                newItem = new BucklerItem();
                break;
            case "sword":
                newItem = new SwordItem();
                break;
            case "armor":
                newItem = new ArmorItem();
                break;
            default:
                newItem = new SwordItem();
                break;
        }
        EquippedItems.Add(newItem);
        newItem.OnItemUsed += OnItemUsed; 
        return this;
    }

    private void OnItemUsed(object? sender, EventArgs e)
    {
        if (sender is not IItem item)
            return;
        
        if (item.Uses == 0)
            EquippedItems.Remove(item);
        
        item.OnItemUsed -= OnItemUsed;
    }

    public void TakeDamage(int amount)
    {
        int damageReduction = 0;

        foreach (var defensiveItem in EquippedItems
                     .Where(r => r is IDefensiveItem)
                     .Cast<IDefensiveItem>())
        {
            damageReduction += defensiveItem.Armor;
        }
        HitPoints(amount - damageReduction);
    }
}