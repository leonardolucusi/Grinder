using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{
    public GameObject inventoryPanel;
    Image image;
    void Start()
    {

        Transform panelTransform = inventoryPanel.transform;
        for (int i = 0; i < panelTransform.childCount; i++)
        {
            Transform slots = panelTransform.GetChild(i);
            slots.GetComponent<Item>().sendItem += UpdateImage;
        }
        image = gameObject.GetComponent<Image>();
    }

    void UpdateImage(GameObject slot)
    {
        Item item = slot.GetComponent<Item>();
        Debug.Log(item + " Received!");
        image.sprite = item.sprite;
    }
}
