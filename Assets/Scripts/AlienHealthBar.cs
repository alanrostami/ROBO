using UnityEngine;
using UnityEngine.UI;

public class AlienHealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public Color lowHealth;
    public Color highHealth;
    public Vector3 heightOffset;

    public void SetHealth(float health, float maxHealth)
    {
        healthSlider.gameObject.SetActive(health < maxHealth);
        healthSlider.value = health;
        healthSlider.maxValue = maxHealth;

        healthSlider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(lowHealth, highHealth, healthSlider.normalizedValue);
    }

    void Update()
    {
        healthSlider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + heightOffset);
    }
}
