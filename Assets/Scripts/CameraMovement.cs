using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float smoothSpeed = 5f;

    private Vector3 offset;

    private void Start()
    {
        // Kameran et‰isyys pelaajasta
        offset = transform.position - player.position;
    }

    private void LateUpdate()
    {
        if (player == null) return;

        // Haluttu sijainti
        Vector3 targetPosition =
            player.position + offset;

        // Pidet‰‰n kameran Z oikein 2D:ss‰
        targetPosition.z = transform.position.z;

        // Pehme‰ liike
        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            smoothSpeed * Time.deltaTime
        );
    }
}