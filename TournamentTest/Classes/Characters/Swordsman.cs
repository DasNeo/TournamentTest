using TournamentTest.Characters.Interfaces;
using TournamentTest.Classes.Characters;
using TournamentTest.Classes.Items.Interfaces;
using TournamentTest.Items;

namespace TournamentTest.Characters;

public class Swordsman : Warrior
{
    public Swordsman(string perk = "") : base(perk)
    {
        EquipItem("sword");
    }
    
    public new Swordsman Equip(string name) => EquipItem(name) as Swordsman;
}