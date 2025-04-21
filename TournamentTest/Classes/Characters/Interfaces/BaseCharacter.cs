using System.Diagnostics;
using TournamentTest.Classes.Items;
using TournamentTest.Classes.Items.Interfaces;
using TournamentTest.Classes.Perks;
using TournamentTest.Perks;
using TournamentTest.Perks.Interfaces;

namespace TournamentTest.Classes.Characters.Interfaces;

public class BaseCharacter
{
    public int MaxHealth { get; init; }
    public int Health { get; private set; }
    public List<IItem> EquippedItems { get; set; } = new List<IItem>();
    public List<IPerk> Perks { get; set; } = new List<IPerk>();

    public BaseCharacter(string perk, int health)
    {
        MaxHealth = health;
        Health = health;
        ApplyPerk(perk);
    }
    
    public void Engage(BaseCharacter other)
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
            
            other.TakeDamage(this, weapon);
            if (other.HitPoints() <= 0)
                return; // if our opponent dies before he can hit we don't take damage
            TakeDamage(other, otherWeapon);
        }
    }

    public int HitPoints(int reduction = -1)
    {
        if (reduction != -1)
            Health = reduction;
        
        return Math.Clamp(Health, 0, MaxHealth);
    }

    internal BaseCharacter ApplyPerk(string perkName)
    {
        IPerk perk;
        switch (perkName)
        {
            case "Vicious":
                perk = new ViciousPerk(this);
                break;
            case "Veteran":
                perk = new VeteranPerk(this);
                break;
            default:
                return this;
        }
        Perks.Add(perk);
        return this;
    }

    internal BaseCharacter EquipItem(string itemName)
    {
        IItem item;
        switch (itemName)
        {
            case "axe":
                item = new AxeItem();
                break;
            case "buckler":
                item = new BucklerItem();
                break;
            case "sword":
                item = new SwordItem();
                break;
            case "armor":
                item = new ArmorItem();
                break;
            case "greatsword":
                item = new GreatSword();
                break;
            default:
                return this;
        }

        var oldWeapon = EquippedItems.FirstOrDefault(r => r is IOffensiveItem);
        if (oldWeapon is not null && item is IOffensiveItem)
            EquippedItems.Remove(oldWeapon);
            
        EquippedItems.Add(item);
        item.OnItemBroken += OnItemBroken; 
        return this;
    }

    private void OnItemBroken(object? sender, EventArgs e)
    {
        if (sender is not IItem item)
            return;
        
        EquippedItems.Remove(item);
        item.OnItemBroken -= OnItemBroken;
    }

    public void TakeDamage(BaseCharacter attacker, IItem attackerWeapon)
    {
        int damageReduction = 0;
        int attackReduction = attacker.EquippedItems
            .Where(r => r is IDefensiveItem item && item.SelfDamageReduction != null)
            .Cast<IDefensiveItem>()
            .Sum(r => r.SelfDamageReduction);
        
        int damage = attackerWeapon.Use() - attackReduction;
        if (damage <= 0)
            return;
        
        // Take perks into account
        foreach (var perk in attacker.Perks
                     .Where(r => r.IsActive))
        {
            damage = perk.Use(damage);
        }
        
        // Take defensive items into account
        foreach (var defensiveItem in EquippedItems
                     .Where(r => r is IDefensiveItem)
                     .Cast<IDefensiveItem>()
                     .ToList())
        {
            damageReduction += defensiveItem.Use(attackerWeapon.Type, damage);
        }

        var calculatedDamage = Math.Clamp(damage - damageReduction, 0, damage);
        Debug.WriteLine($"{attackerWeapon.Name} dealt {calculatedDamage} damage");
        HitPoints(Health - calculatedDamage);
    }
}