using UnityEngine;

public class TrashBin : MonoBehaviour
{
    [SerializeField] private int moneyPerTrash = 10;

    private bool playerNearby = false;
    private PlayerTrashInventory inventory;

    private void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            if (inventory != null)
            {
                if (inventory.trashCount > 0)
                {
                    inventory.SellTrash(moneyPerTrash);

                    Debug.Log("✔ Roskat myyty");

                    // Spawn vasta kun myydään
                    TrashSpawner.Instance.TrashCollected();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        playerNearby = true;

        inventory = other.GetComponent<PlayerTrashInventory>();

        Debug.Log("✔ Pelaaja roskakorilla");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        playerNearby = false;
        inventory = null;
    }
}