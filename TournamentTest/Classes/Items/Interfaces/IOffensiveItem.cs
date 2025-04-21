namespace TournamentTest.Classes.Items.Interfaces;

public interface IOffensiveItem : IItem
{
    public abstract int Damage { get; set; }
}