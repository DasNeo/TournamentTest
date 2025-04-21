namespace TournamentTest.Classes.Items.Interfaces;

public interface IDefensiveItem : IItem
{
    public int Armor { get; set; }
    public bool BlockAllDamage { get; set; }
    public int SelfDamageReduction { get; set; }

    public int Use(ItemType attackerWeapon, int incomingDamage);
}