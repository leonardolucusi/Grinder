using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject InventoryPanel;
    public GameObject InventoryInteractionPanel;

    public void OpenInventory()
    {
        gameObject.SetActive(false);
        InventoryPanel.SetActive(!InventoryPanel.activeSelf);
        InventoryInteractionPanel.SetActive(!InventoryInteractionPanel.activeSelf);
        Debug.Log("Button clicked");
    } 
}
