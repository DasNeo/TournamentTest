using TournamentTest.Classes.Characters.Interfaces;

namespace TournamentTest.Perks.Interfaces;

public interface IPerk
{
    public BaseCharacter Owner { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; }
    public abstract int Use(int val);
}