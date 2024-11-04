using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1;

    void Update()
    {
        // move player
        transform.position += transform.forward * speed * Input.GetAxis("Vertical") * Time.deltaTime;
        transform.position += transform.right * speed * Input.GetAxis("Horizontal") * Time.deltaTime;
    }
}
