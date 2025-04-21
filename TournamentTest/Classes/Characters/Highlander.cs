namespace TournamentTest.Classes.Characters;

public class Highlander : Warrior
{
    public Highlander(string perk = "") : base(perk, 150)
    {
        EquipItem("greatsword");
    }
    
    public new Highlander Equip(string name) => EquipItem(name) as Highlander;
}