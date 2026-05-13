using UnityEngine;

public class PlayerTrashInventory : MonoBehaviour
{
    public int trashCount = 0;

    public void AddTrash()
    {
        trashCount++;
        Debug.Log("Roskia mukana: " + trashCount);
    }

    public void SellTrash(int moneyPerTrash)
    {
        if (trashCount <= 0) return;

        int totalMoney = trashCount * moneyPerTrash;

        PlayerDataManager.Instance.AddMoney(totalMoney);

        Debug.Log("Sait rahaa: " + totalMoney);

        trashCount = 0;
    }
}