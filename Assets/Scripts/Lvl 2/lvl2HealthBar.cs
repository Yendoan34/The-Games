using UnityEngine;

public class lvl2HealthBar : MonoBehaviour
{
    public Transform fill;  // The fill transform
    public Transform background;  // The background transform
    public EnemyHealth2 enemy;  // Reference to the Enemy script

    private Vector3 initialFillScale;

    void Start()
    {
        // Store the initial scale of the fill
        initialFillScale = fill.localScale;

        // Ensure we start with the correct health value
        if (enemy != null)
        {
            SetHealth((float)enemy.hitPoints / enemy.maxHP);
        }
    }

    void Update()
    {
        if (enemy != null)
        {
            // Update health bar based on the enemy's health
            SetHealth((float)enemy.hitPoints / enemy.maxHP);
        }
    }

    public void SetHealth(float value)
    {
        // Ensure the health value is between 0 and 1
        value = Mathf.Clamp01(value);
        UpdateHealthBar(value);
    }

    private void UpdateHealthBar(float value)
    {
        // Update the fill based on the health value
        Vector3 scale = initialFillScale;
        scale.x = initialFillScale.x * value;
        fill.localScale = scale;
    }
}
