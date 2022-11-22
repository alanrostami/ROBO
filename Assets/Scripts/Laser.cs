using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // public GameObject greenAlien;

    void Start()
    {
        // greenAlien = GameObject.Find("GreenAlien");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Alien")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            // GameObject.Find("AlienLogic").GetComponent<AlienLogic>().SpawnAlien(greenAlien);
        }
    }
}
