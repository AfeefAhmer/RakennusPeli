using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI Instance;

    [Header("UI")]
    public GameObject inventoryPanel;
    public Transform itemContainer;
    public GameObject buttonPrefab;

    [Header("Build")]
    public BuildingPlacer buildingPlacer;

    private List<Tavara> currentItems = new List<Tavara>();

    // Tallennetaan item -> button yhteys
    private Dictionary<Tavara, GameObject> itemButtons = new Dictionary<Tavara, GameObject>();

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
    }

    public void ToggleInventory()
    {
        //inventoryPanel.SetActive(!inventoryPanel.activeSelf);

        if (inventoryPanel.activeSelf)
            Refresh();
    }

    public void Refresh()
    {
        // Poista vanhat napit
        foreach (Transform child in itemContainer)
        {
            Destroy(child.gameObject);
        }

        itemButtons.Clear();

        currentItems = PlayerInventory.Instance.GetItems();

        foreach (Tavara item in currentItems)
        {
            GameObject btnObj = Instantiate(buttonPrefab, itemContainer);

            TMP_Text txt = btnObj.GetComponentInChildren<TMP_Text>();
            txt.text = item.itemName;

            Button btn = btnObj.GetComponent<Button>();

            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(() =>
            {
                SelectItem(item, btnObj);
            });

            itemButtons[item] = btnObj;
        }
    }

    void SelectItem(Tavara item, GameObject buttonObj)
    {
        if (item.isBuilding)
        {
            buildingPlacer.StartPlacing(item.prefab);

            // Poista vain tämä nappi UI:sta
            Destroy(buttonObj);

            // Poista listasta
            currentItems.Remove(item);
            itemButtons.Remove(item);
        }
    }
}