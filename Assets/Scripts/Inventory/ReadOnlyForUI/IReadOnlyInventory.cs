using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Inventory.ReadOnlyForUI
{
    public interface IReadOnlyInventory
    {
        event Action<string, int> ItemsAdded; // событие добавления
        event Action<string, int> ItemsRemoved;

        string OwnerId { get; }

        int GetAmount(string itemId);
        bool Has(string ItemId, int amount);
    }

}
