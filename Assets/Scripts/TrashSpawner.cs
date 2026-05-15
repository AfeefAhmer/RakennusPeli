using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    public static TrashSpawner Instance;

    [SerializeField] private GameObject trashPrefab;
    [SerializeField] private Transform[] spawnPoints;

    private GameObject currentTrash;

    private void Awake()
    {
        Instance = this;

        Debug.Log("Spawner object: " + gameObject.name);
        Debug.Log("Prefab: " + trashPrefab);
    }

    private void Start()
    {
        SpawnTrash();
    }

    public void TrashCollected()
    {
        currentTrash = null;

        SpawnTrash();
    }

    private void SpawnTrash()
    {
        if (trashPrefab == null)
        {
            Debug.LogError("❌ TrashPrefab puuttuu!");
            return;
        }

        if (spawnPoints.Length == 0)
        {
            Debug.LogError("❌ SpawnPoints puuttuu!");
            return;
        }

        int randomIndex = Random.Range(0, spawnPoints.Length);

        currentTrash = Instantiate(
            trashPrefab,
            spawnPoints[randomIndex].position,
            Quaternion.identity
        );

        Debug.Log("✔ Roska spawnattu");
    }
}