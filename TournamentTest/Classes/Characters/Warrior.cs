using TournamentTest.Classes.Characters.Interfaces;

namespace TournamentTest.Classes.Characters;

public class Warrior(string perk, int health = 100) : BaseCharacter(perk, health)
{
    public Warrior Equip(string name) => EquipItem(name) as Warrior;
}