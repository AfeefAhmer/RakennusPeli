using UnityEngine;
using UnityEngine.InputSystem;
public class BuildingPlacer : MonoBehaviour
{
    private GameObject currentPrefab;

    private bool placing = false;

    void Update()
    {
        if (!placing) return;

        if (Input.GetMouseButtonDown(0))
        {
            PlaceBuilding();
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

        Debug.Log("Rakennuksen sijoitus aloitettu");
    }

    void PlaceBuilding()
    {
       Vector3 before= Mouse.current.position.ReadValue();
        before.z = Camera.main.nearClipPlane+10;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(before);
        mousePos.z = 0f;


        Instantiate(currentPrefab, mousePos, Quaternion.identity);

        Debug.Log("Rakennus rakennettu"+mousePos);

        placing = false;
    }

    void CancelPlacement()
    {
        placing = false;

        Debug.Log("Rakentaminen peruttu");
    }
}