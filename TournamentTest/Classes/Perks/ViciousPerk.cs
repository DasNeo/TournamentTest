using TournamentTest.Characters.Interfaces;
using TournamentTest.Classes.Items.Interfaces;
using TournamentTest.Perks.Interfaces;

namespace TournamentTest.Perks;

public class ViciousPerk(BaseCharacter owner) : IPerk
{
    public BaseCharacter Owner { get; set; } = owner;
    public string Name { get; set; } = "Vicious";
    public bool IsActive => _useCounter < 3;
    
    private readonly int _damageIncrease = 20;
    private int _useCounter = 0;

    public int Use(int damage)
    {
        if (!IsActive)
            return damage;
        
        _useCounter++;
        switch (_useCounter)
        {
            case 1:
            case 2:
                damage += _damageIncrease;
                break;
        }
        return damage;
    }
}