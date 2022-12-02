using UnityEngine;

public class AlienHitPoints : MonoBehaviour
{
    public float hitPoints;
    public float maxHitPoints = 5;
    public AlienHealthBar greenAlienHealthBar;

    void Start()
    {
        hitPoints = maxHitPoints;
        greenAlienHealthBar.SetHealth(hitPoints, maxHitPoints);
    }

    public void TakeHit(float damage)
    {
        hitPoints -= damage;
        greenAlienHealthBar.SetHealth(hitPoints, maxHitPoints);

        if (hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
