﻿namespace TournamentTest.Classes.Items.Interfaces;

public interface IItem
{
    public enum ItemType
    {
        Buckler,
        Axe,
        Armor,
        Sword,
        GreatSword
    }
    
    public string Name { get; set; }
    public int Uses { get; set; }
    public ItemType Type { get; set; }
    public int Cooldown { get; set; }

    public int Use();

    public event EventHandler OnItemBroken;
}