using TournamentTest.Classes.Items.Interfaces;

namespace TournamentTest.Classes.Items;

public class GreatSword : IOffensiveItem
{
    public string Name { get; set; } = "greatsword";
    public int Uses { get; set; } = -1;
    public IItem.ItemType Type { get; set; }
    public int Cooldown { get; set; } = 3;
    private int _useCounter = 0;
    
    public int Use()
    {
        _useCounter++;
        switch (_useCounter)
        {
            case 1:
            case 2:
                return Damage;
            default:
                _useCounter = 0;
                return 0;
        }
    }

    public event EventHandler? OnItemBroken;
    public int Damage { get; set; } = 12;
}