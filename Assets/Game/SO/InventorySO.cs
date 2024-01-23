using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "InventoryData", menuName = "Inventory Data", order = 1)]
public class InventorySO : ScriptableObject
{
    public List<InventoryItem> items = new List<InventoryItem>();
}

[System.Serializable]
public class InventoryItem : Item
{
    public int idSO;
    public string namedSO;
    public int damageSO;
    public float attackSpeedSO;
    public Sprite spriteSO;

    public InventoryItem(int id, string named, int damage, float attackSpeed, Sprite sprite) : base(id, named, damage, attackSpeed, sprite)
    {
    }
}