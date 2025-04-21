using TournamentTest.Characters.Interfaces;
using TournamentTest.Classes.Items.Interfaces;
using TournamentTest.Items;

namespace TournamentTest.Classes.Characters;

public class Warrior(int health = 100) : BaseCharacter(health)
{
    public Warrior Equip(string name) => EquipItem(name) as Warrior;
}