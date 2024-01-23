using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    public event Action<GameObject> sendItem;
    public int id;
    public string named;
    public int damage;
    public float attackSpeed;
    public Sprite sprite;
    public Item(int id, string named, int damage, float attackSpeed, Sprite sprite)
    {
        this.id = id;
        this.named = named;
        this.damage = damage;
        this.attackSpeed = attackSpeed;
        this.sprite = sprite;
    }

    public void SendItem()
    {
        Debug.Log("Event sent:" + this);
        sendItem?.Invoke(gameObject);
    }
}