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
    }

    private void Start()
    {
        SpawnTrash();
    }

    public void SpawnTrash()
    {
        if (currentTrash != null) return;

        int randomIndex = Random.Range(0, spawnPoints.Length);

        Transform spawnPoint = spawnPoints[randomIndex];

        currentTrash = Instantiate(
            trashPrefab,
            spawnPoint.position,
            Quaternion.identity
        );
    }

    public void TrashCollected()
    {
        currentTrash = null;

        SpawnTrash();
    }
}