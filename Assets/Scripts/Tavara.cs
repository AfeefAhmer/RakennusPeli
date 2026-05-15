using UnityEngine;

public enum ItemType
{
    Building,
    Car
}

public class Tavara : MonoBehaviour
{
    public string itemName;
    public ItemType itemType;
    public GameObject prefab;
}