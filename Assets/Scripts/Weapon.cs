using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject laserPrefab;
    public Transform laserPoint;
    public float laserForce = 20.0f;

    public void ShootLaser()
    {
        GameObject laser = Instantiate(laserPrefab, laserPoint.position, laserPoint.rotation);
        laser.GetComponent<Rigidbody2D>().AddForce(laserPoint.up * laserForce, ForceMode2D.Impulse);
    }
}
