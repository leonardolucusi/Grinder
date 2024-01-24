using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{

    public GameObject slotPreFab;
    public List<Item> items;
    public int inventorySize;
    public Sprite swordSprite;
    public Sprite daggerSprite;
    public Sprite emptySprite;
    public GameObject sword;
    public GameObject dagger;
    public GameObject empty;

    void Start()
    {
        FullFillList();
        InitializeInventorytSlots();
        ReloadInventory();
    }

    public void FullFillList()
    {
        items = new List<Item>
        {
           sword.GetComponent<Item>(),
           dagger.GetComponent<Item>(),
        };
        while (items.Count < inventorySize)
        {
            items.Add(empty.GetComponent<Item>());
        }
    }

    public void InitializeInventorytSlots()
    {
        for (int i = 0; i < inventorySize; i++)
        {
            GameObject slot = Instantiate(slotPreFab, new Vector3(0, 0, 0), Quaternion.identity);
            slot.transform.SetParent(gameObject.transform);
            slot.transform.localScale = new Vector3(1, 1, 1);
            if (i >= 8)
            {
                slot.transform.position = new Vector3(40f + (i - 8) * 50f, 200f, 0);
            }
            else
            {
                slot.transform.position = new Vector3(40f + i * 50f, 250f, 0);
            }
        }
    }

    public void AddItemToInventorySlot(Item item, GameObject slot)
    {
        Item slotItem = slot.GetComponent<Item>();
        slotItem.id = item.id;
        slotItem.named = item.named;
        slotItem.damage = item.damage;
        slotItem.attackSpeed = item.attackSpeed;
        slotItem.sprite = item.sprite;
        Image buttonImage = slot.GetComponent<Image>();
        buttonImage.sprite = item.sprite;
    }

    public void ReloadInventory()
    {
        Transform panelTransform = gameObject.transform;
        for (int i = 0; i < panelTransform.childCount; i++)
        {
            Transform slot = panelTransform.GetChild(i);
            AddItemToInventorySlot(items[i], slot.gameObject);
        }
    }
   
}
