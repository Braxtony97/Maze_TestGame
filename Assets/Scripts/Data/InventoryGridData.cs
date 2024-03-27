using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Data
{
    [Serializable] // Сможем сериализовать и сохранять в json
    public class InventoryGridData
    {
        public string OwnerId; // Владелец инвентаря
        public List<InventorySlotData> Slot;
        public Vector2Int Size; // Размер инвентаря
    }
}