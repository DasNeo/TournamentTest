using TournamentTest.Characters.Interfaces;
using TournamentTest.Classes.Items.Interfaces;
using TournamentTest.Items;

namespace TournamentTest.Classes.Characters;

public class Warrior : ICharacter
{
    public int Damage { get; set; } = 5;
    public int Health { get; set; } = 100;
    public List<IItem> EquippedItems { get; set; } = new List<IItem>()
    {
        new SwordItem()
    };
    
    public Warrior Equip(string name) => ((ICharacter)this).EquipItem(name) as Warrior;
    public void Engage(ICharacter other) => ((ICharacter)this).Engage(other);
    public int HitPoints() => ((ICharacter)this).HitPoints();
}