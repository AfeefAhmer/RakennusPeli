using UnityEngine;
using TMPro;

public class PlayerDataManager : MonoBehaviour
{
    public static PlayerDataManager Instance { get; private set; }

    [SerializeField] private int money = 100000;
    [SerializeField] private TMP_Text coinText;

    public int Money => money;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (coinText != null)
            coinText.text = "Coins: " + money;
    }

    public int AddMoney(int amount)
    {
        if (amount <= 0) return money;

        money += amount;
        UpdateUI();
        return money;
    }

    public bool TakeMoney(int amount)
    {
        if (amount <= 0) return true;
        if (money < amount) return false;

        money -= amount;
        UpdateUI();
        return true;
    }
}