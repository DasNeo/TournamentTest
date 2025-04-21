using TournamentTest.Classes.Items.Interfaces;

namespace TournamentTest.Utils;

public static class ItemExtensions
{
    public static IItem? Find(this List<IItem> itemList, IItem.ItemType itemType) 
        => itemList.FirstOrDefault(r => r.Type == itemType);
}