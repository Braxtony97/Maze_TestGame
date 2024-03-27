using System;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Data
{
    [Serializable] // Сможем сериализовать и сохранять в json
    public class InventorySlotData
    {
        public string ItemId;
        public int Amount;
    }
}