using TournamentTest.Classes.Characters.Interfaces;
using TournamentTest.Perks.Interfaces;

namespace TournamentTest.Perks;

public class VeteranPerk(BaseCharacter owner) : IPerk
{
    public BaseCharacter Owner { get; set; } = owner;
    public string Name { get; set; } = "Veteran";
    public bool IsActive
    {
        get => Owner.Health <= _healthPercentThreshold * Owner.MaxHealth / 100;
    }

    private readonly int _damageMultiplier = 2;
    private readonly int _healthPercentThreshold = 30;
    
    public int Use(int val) => IsActive ? val * _damageMultiplier : val;
}