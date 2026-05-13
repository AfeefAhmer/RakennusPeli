using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class PlayerMachineInteraction : MonoBehaviour
{
    private MachineInfo currentMachine;

    [Header("Building UI")]
    public GameObject buildingPanel;
    public TextMeshProUGUI buildingNameLabel;
    public TMP_Dropdown buildingDropdown;
    public TextMeshProUGUI buildingPriceText;
    public Button buildingBuyButton;
    public Button buildingCancelButton;

    [Header("Car UI")]
    public GameObject carPanel;
    public TextMeshProUGUI carNameLabel;
    public TMP_Dropdown carDropdown;
    public TextMeshProUGUI carPriceText;
    public Button carBuyButton;
    public Button carCancelButton;

    [Header("Prefabs")]
    public List<GameObject> buildingPrefab;
    private int SelectedBuilding = 0;
    public GameObject carPrefab;

    private int selectedBuilding;
    private int selectedCar;
    private int currentCost;

    private bool playerNearMachine = false;

    void Start()
    {
        CloseMachine();

        buildingBuyButton.onClick.AddListener(BuyItem);
        buildingCancelButton.onClick.AddListener(CloseMachine);

        carBuyButton.onClick.AddListener(BuyItem);
        carCancelButton.onClick.AddListener(CloseMachine);
    }

    void Update()
    {
        // Avaa kauppa E-näppäimellä
        if (playerNearMachine && Input.GetKeyDown(KeyCode.E))
        {
            OpenMachine();
        }

        // Sulje ESC:llä
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseMachine();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        MachineInfo merchant = other.GetComponent<MachineInfo>();

        if (merchant != null)
        {
            currentMachine = merchant;
            playerNearMachine = true;

            Debug.Log("Paina E avataksesi kaupan");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (currentMachine != null &&
            other.GetComponent<MachineInfo>() == currentMachine)
        {
            CloseMachine();

            currentMachine = null;
            playerNearMachine = false;
        }
    }

    void OpenMachine()
    {
        if (currentMachine == null) return;

        CloseMachine();

        // ===== BUILDINGS =====
        if (currentMachine.machineType == MachineType.BuildingMachine)
        {
            buildingPanel.SetActive(true);
            buildingNameLabel.text = currentMachine.merchantName;

            SetupDropdown(
                buildingDropdown,
                currentMachine.GetRakennusNames(),
                val =>
                {
                    selectedBuilding = val;
                    UpdateBuildingCost();
                });

            UpdateBuildingCost();
        }

        // ===== CARS =====
        else if (currentMachine.machineType == MachineType.CarMachine)
        {
            carPanel.SetActive(true);
            carNameLabel.text = currentMachine.merchantName;

            SetupDropdown(
                carDropdown,
                currentMachine.GetAutoNames(),
                val =>
                {
                    selectedCar = val;
                    UpdateCarCost();
                });

            UpdateCarCost();
        }
    }

    void CloseMachine()
    {
        buildingPanel.SetActive(false);
        carPanel.SetActive(false);

        currentCost = 0;
    }

    void SetupDropdown(
        TMP_Dropdown dropdown,
        string[] options,
        System.Action<int> onChange)
    {
        dropdown.ClearOptions();

        dropdown.AddOptions(
            new System.Collections.Generic.List<string>(options));

        dropdown.onValueChanged.RemoveAllListeners();

        dropdown.onValueChanged.AddListener(
            val => onChange.Invoke(val));

        dropdown.value = 0;
        dropdown.RefreshShownValue();
    }

    // ===== BUILDING =====
    void UpdateBuildingCost()
    {
        currentCost = currentMachine.GetBuildingPrice(selectedBuilding);

        buildingPriceText.text = "Hinta: " + currentCost + " kultaa";
    }

    // ===== CAR =====
    void UpdateCarCost()
    {
        currentCost = currentMachine.GetCarPrice(selectedCar);

        carPriceText.text = "Hinta: " + currentCost + " kultaa";
    }

    public void BuildingSelect(int Choice)
    {
        SelectedBuilding = Choice;
    }
    void BuyItem()
    {
        Debug.Log("BUY ITEM");

        Debug.Log("currentMachine: " + currentMachine);
        Debug.Log("buildingPrefab: " + buildingPrefab);
        Debug.Log("PlayerInventory.Instance: " + PlayerInventory.Instance);

        PlayerController controller = GetComponent<PlayerController>();

        Debug.Log("controller: " + controller);

        if (currentMachine == null || currentCost <= 0)
            return;

        if (!PlayerDataManager.Instance.TakeMoney(currentCost))
        {
            Debug.Log("Ei tarpeeksi rahaa!");
            return;
        }

        if (currentMachine.machineType == MachineType.BuildingMachine)
        {
            Tavara tavara = buildingPrefab[SelectedBuilding].GetComponent<Tavara>();

            Debug.Log("tavara: " + tavara);

            if (tavara == null)
            {
                Debug.LogError("Tavara script puuttuu prefabista!");
                return;
            }

            if (!controller.OstoLisatty(tavara))
            {
                PlayerDataManager.Instance.AddMoney(currentCost);

                Debug.Log("Reppu täynnä!");
                return;
            }

            PlayerInventory.Instance.AddItem(tavara);

            Debug.Log("Rakennus lisätty inventoryyn");
        }
        InventoryUI.Instance.Refresh();
    }
}