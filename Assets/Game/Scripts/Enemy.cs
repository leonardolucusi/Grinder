using System.Collections;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    [SerializeField] private readonly int xp = 3;
    public int currentHealth;
    public bool invunerability = false;
    private SpriteRenderer sr;
    private Color originalColor;
    internal object patrolPoints;
    public Item item;
    public InventorySystem inventorySystem;
    void Start()
    {
        currentHealth = maxHealth;
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
    }
    public void TakeDamage(int damage)
    {
        if (invunerability == false)
        {
            Debug.Log("Damage received: " + damage + " Health remaining: " + (currentHealth - damage));
            currentHealth -= damage;
            if (currentHealth <= 0) Die(); else StartCoroutine(Invunerability());
        }
        else Debug.Log("Invunerable");
    }
    void Die()
    {
        ItemReward();
        Debug.Log("Enemy Died!");
    }
    public int xpReward()
    {
        return xp;
    }
    IEnumerator Invunerability()
    {
        invunerability = true;
        sr.color = Color.red;
        yield return new WaitForSeconds(2.5f);
        sr.color = originalColor;
        invunerability = false;
    }
    public void ItemReward()
    {
        if (Random.Range(1, 10) >= 5)
        {
            for (int i = 0; i < inventorySystem.inventorySize; i++)
            {
                if (inventorySystem.items[i].named == "empty")
                {
                    inventorySystem.items[i] = item;
                    inventorySystem.ReloadInventory();
                    Debug.Log("Item " + item.name + "added to inventory!");
                    return;
                }
            }
            Debug.Log("Inventory is full!");
        }
        Debug.Log(gameObject.name + " drops nothing!");

    }
}
