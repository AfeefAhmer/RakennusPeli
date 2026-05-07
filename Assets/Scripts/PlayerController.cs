using UnityEngine;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;

    [Header("Inventory")]
    public int maxInventorySize = 10;
    private List<Tavara> inventory = new List<Tavara>();

    [Header("Stats")]
    public int health = 100;

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, moveY, 0f);
        transform.Translate(movement * speed * Time.deltaTime);
    }

    // ================= INVENTORY =================
    public bool OstoLisatty(Tavara tavara)
    {
        if (tavara == null)
        {
            Debug.LogWarning("Yritettiin lisätä null tavara!");
            return false;
        }

        if (inventory.Count >= maxInventorySize)
        {
            Debug.Log("Inventory täynnä!");
            return false;
        }

        inventory.Add(tavara);

        Debug.Log("Lisätty inventoryyn: " + tavara);
        return true;
    }


    // ================= AUTO BOOST =================
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
        Debug.Log("Uusi nopeus: " + speed);
    }

    // ================= HEALTH =================
    public void AddHealth(int amount)
    {
        health += amount;
        health = Mathf.Clamp(health, 0, 100);

        Debug.Log("Health: " + health);
    }
}