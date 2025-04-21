namespace TournamentTest;

public class TournamentClassBase
{
    [Flags]
    public enum EquippableItems
    {
        Buckler,
        Armor,
        Axe,
    }
    
    private int _hitpoints { get; set; }
    private int _damage { get; set; }

    public int HitPoints() => _hitpoints;
    public int Damage() => _damage;

    public EquippableItems EquippedItems;

    public void Equip(string itemName)
    {
        if(Enum.TryParse(itemName, true, out EquippableItems item))
            EquippedItems |= item;
    }

    public void Engage(TournamentClassBase other)
    {
        while (HitPoints() > 0 && other.HitPoints() > 0)
        {
            other.TakeDamage(_damage);
            TakeDamage(other.Damage());
        }
    }

    public void TakeDamage(int amount)
    {
        if ((EquippableItems.Buckler & EquippedItems) != 0)
        {
            
        }
    }
}