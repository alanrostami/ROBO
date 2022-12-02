using UnityEngine;

public class Laser : MonoBehaviour
{
    // public GameObject greenAlien;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Alien")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
