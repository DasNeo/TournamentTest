namespace TournamentTest.Classes.Characters;

public class Swordsman : Warrior
{
    public Swordsman(string perk = "") : base(perk)
    {
        EquipItem("sword");
    }
    
    public new Swordsman Equip(string name) => EquipItem(name) as Swordsman;
}