using UnityEngine;

public class TrashPickup : MonoBehaviour
{
    private bool playerNearby;
    private PlayerTrashInventory inventory;

    private void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            if (inventory != null)
            {
                inventory.AddTrash();
            }

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        playerNearby = true;
        inventory = other.GetComponent<PlayerTrashInventory>();

        Debug.Log("Player entered trash");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        playerNearby = false;
        inventory = null;
    }
}