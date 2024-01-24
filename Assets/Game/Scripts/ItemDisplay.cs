using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{
    public GameObject playerWeapon;
    public GameObject inventoryPanel;
    Image image;
    public Item myItem;
    void Start()
    {
        myItem = gameObject.GetComponent<Item>();

        Transform panelTransform = inventoryPanel.transform;
        for (int i = 0; i < panelTransform.childCount; i++)
        {
            Transform slots = panelTransform.GetChild(i);
            slots.GetComponent<Item>().sendItem += UpdateItemDisplay;
        }
        image = gameObject.GetComponent<Image>();
    }

    void UpdateItemDisplay(GameObject slot)
    {
        Item item = slot.GetComponent<Item>();
        myItem.id = item.id;
        myItem.named = item.named;
        myItem.damage = item.damage;
        myItem.attackSpeed = item.attackSpeed;
        image.sprite = item.sprite;
        Debug.Log(item + " Received!");
    }

    public void EquipItem()
    {
        Debug.Log("Equip button works!");
        Item weaponDisplay = myItem.GetComponent<Item>();
        Item plrWeapon = playerWeapon.GetComponent<Item>();
        plrWeapon.GetComponent<SpriteRenderer>().sprite = image.sprite;
        plrWeapon.id = weaponDisplay.id;
        plrWeapon.named = weaponDisplay.named;
        plrWeapon.damage = weaponDisplay.damage;
        plrWeapon.attackSpeed = weaponDisplay.attackSpeed;

    }
}
