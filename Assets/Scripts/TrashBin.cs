using UnityEngine;
using TMPro;

public class TrashBin : MonoBehaviour
{
    [SerializeField] private int moneyPerTrash = 10;
    [SerializeField] private TMP_Text interactionText;

    private bool playerNearby = false;
    private PlayerTrashInventory currentInventory;

    private void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            if (currentInventory != null)
            {
                currentInventory.SellTrash(moneyPerTrash);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;

            currentInventory =
                other.GetComponent<PlayerTrashInventory>();

            interactionText.text = "Laita roska [E]";
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            interactionText.text = "";
        }
    }
}