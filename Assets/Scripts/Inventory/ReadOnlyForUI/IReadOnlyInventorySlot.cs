using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Inventory.ReadOnlyForUI
{
    public interface IReadOnlyInventorySlot // Будем передавать его в View
    {
        event Action<string> ItemIdChanged; // Событие при изменении item
        event Action<int> ItemAMountChanged;

        string ItemId { get; } // только с доступом на чтение
        int Amount { get; }
        bool IsEmpty { get; }
    }
}
