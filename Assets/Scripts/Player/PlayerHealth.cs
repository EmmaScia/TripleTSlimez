using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 600f;
    [SerializeField] private float regenDelay = 5f;
    [SerializeField] private float regenRate = 100f;

    public Slider healthSlider;

    private float currentHealth;
    private float regenTimer;

    void Awake()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
        regenTimer = regenDelay;
    }

    void Update()
    {
        if (currentHealth <= 0f || currentHealth >= maxHealth) return;

        regenTimer -= Time.deltaTime;
        if (regenTimer <= 0f)
        {
            currentHealth = Mathf.Min(currentHealth + regenRate * Time.deltaTime, maxHealth);
            healthSlider.value = currentHealth;
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0f, maxHealth);
        healthSlider.value = currentHealth;
        regenTimer = regenDelay;

        if (currentHealth <= 0f)
            Die();
    }

    private void Die()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.GameOver();
    }
}
