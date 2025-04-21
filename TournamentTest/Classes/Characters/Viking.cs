using TournamentTest.Characters.Interfaces;
using TournamentTest.Classes.Characters;
using TournamentTest.Classes.Items.Interfaces;
using TournamentTest.Items;

namespace TournamentTest.Characters;

public class Viking : Warrior
{
    public new int Health { get; set; } = 120;

    public new List<IItem> EquippedItems { get; set; } = new List<IItem>()
    {
        new AxeItem(),
    };
}