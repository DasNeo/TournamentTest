using TournamentTest.Characters.Interfaces;
using TournamentTest.Classes.Characters;

namespace TournamentTest.Characters;

public class Viking : Warrior
{
    public Viking(string perk = "") : base(perk, 120)
    {
        EquipItem("axe");
    }
    
    public new Viking Equip(string name) => EquipItem(name) as Viking;
}