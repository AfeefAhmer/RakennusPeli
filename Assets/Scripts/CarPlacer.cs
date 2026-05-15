using UnityEngine;
using UnityEngine.InputSystem;

public class AutoPlacer : MonoBehaviour
{
    private GameObject currentPrefab;
    private bool placing = false;

    void Update()
    {
        if (!placing) return;

        if (Input.GetMouseButtonDown(0))
        {
            PlaceCar();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CancelPlacement();
        }
    }

    public void StartPlacing(GameObject prefab)
    {
        currentPrefab = prefab;
        placing = true;

        Debug.Log("Auton sijoitus aloitettu");
    }

    void PlaceCar()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        mousePos.z = Camera.main.nearClipPlane + 10;

        Vector3 world = Camera.main.ScreenToWorldPoint(mousePos);
        world.z = 0f;

        Instantiate(currentPrefab, world, Quaternion.identity);

        Debug.Log("Auto sijoitettu " + world);

        placing = false;
    }

    void CancelPlacement()
    {
        placing = false;

        Debug.Log("Auton sijoitus peruttu");
    }
}