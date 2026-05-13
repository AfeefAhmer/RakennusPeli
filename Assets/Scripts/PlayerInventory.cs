using UnityEngine;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance;

    private List<Tavara> items = new List<Tavara>();

    void Awake()
    {
        Instance = this;
    }

    public void AddItem(Tavara item)
    {
        items.Add(item);
    }

    public void RemoveItem(Tavara item)
    {
        items.Remove(item);
    }

    public List<Tavara> GetItems()
    {
        return items;
    }
}