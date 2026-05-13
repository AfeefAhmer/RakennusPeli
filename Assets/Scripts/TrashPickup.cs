using UnityEngine;
using TMPro;

public class TrashPickup : MonoBehaviour
{
    [SerializeField] private TMP_Text interactionText;

    private bool playerNearby = false;
    private bool collected = false;

    private PlayerTrashInventory currentInventory;

    private void Update()
    {
        if (playerNearby &&
            !collected &&
            Input.GetKeyDown(KeyCode.E))
        {
            collected = true;

            if (currentInventory != null)
            {
                currentInventory.AddTrash();

                interactionText.text = "";

                // Estää uuden käytön heti
                GetComponent<Collider2D>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;

                // Spawn uusi roska
                TrashSpawner.Instance.TrashCollected();

                // Poista objekti hetken päästä
                Destroy(gameObject, 0.1f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!collected && other.CompareTag("Player"))
        {
            playerNearby = true;

            currentInventory =
                other.GetComponent<PlayerTrashInventory>();

            interactionText.text = "Ota roska [E]";
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;

            currentInventory = null;

            interactionText.text = "";
        }
    }
}