using System.Diagnostics;
using TournamentTest.Classes.Items.Interfaces;
using TournamentTest.Items;
using TournamentTest.Utils;

namespace TournamentTest.Characters.Interfaces;

public class BaseCharacter(int health)
{
    public int MaxHealth { get; init; } = health;
    public int Health { get; set; } = health;
    public List<IItem> EquippedItems { get; set; } = new List<IItem>();

    private static int _engagementRound = 0;

    public void Engage(BaseCharacter other)
    {
        _engagementRound = 0;
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
            
            other.TakeDamage(weapon.Type, weapon.Use());
            if (other.HitPoints() <= 0)
                return;
            TakeDamage(otherWeapon.Type, otherWeapon.Use());
            if (HitPoints() <= 0)
                return;
            _engagementRound++;
        }
    }

    public int HitPoints(int reduction = -1)
    {
        if (reduction != -1)
            Health = reduction;
        
        return Math.Clamp(Health, 0, MaxHealth);
    }

    internal BaseCharacter EquipItem(string itemName)
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

    public void TakeDamage(IItem.ItemType attackerWeapon, int amount)
    {
        int damageReduction = 0;

        foreach (var defensiveItem in EquippedItems
                     .Where(r => r is IDefensiveItem)
                     .Cast<IDefensiveItem>()
                     .ToList())
        {
            if (_engagementRound % defensiveItem.Cooldown != 0)
                continue;
            damageReduction += defensiveItem.Use(attackerWeapon);
            if (defensiveItem.BlockAllDamage)
                return;
        }

        var calculatedDamage = amount - damageReduction;
        HitPoints(Health - calculatedDamage);
    }
}