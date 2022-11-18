using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Get player's Transform component
    [SerializeField] private Transform player;
    private void Update()
    {
        // Set camera's position to player's position
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
