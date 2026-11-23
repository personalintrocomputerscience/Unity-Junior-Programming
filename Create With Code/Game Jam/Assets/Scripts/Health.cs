using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float maxHealth = 100f;

    private float currentHealth;

    public float CurrentHealth => currentHealth;
    public float MaxHealth => maxHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (currentHealth <= 0f) return;

        currentHealth = Mathf.Clamp(
            currentHealth - damage, 0f, maxHealth
        );

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        if (currentHealth <= 0f) return;

        currentHealth = Mathf.Clamp(
            currentHealth + amount, 0f, maxHealth
        );
    }

    private void Die()
    {
        Debug.Log("Player died!");

        MultiplayerPlayerMovement movement =
            GetComponent<MultiplayerPlayerMovement>();

        if (movement != null)
            movement.enabled = false;
    }
}