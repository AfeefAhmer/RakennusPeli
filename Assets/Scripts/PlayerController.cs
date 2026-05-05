using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public float speed = 5f;

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); 
        float moveY = Input.GetAxis("Vertical");   

        Vector3 movement = new Vector3(moveX, moveY, 0f);
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
