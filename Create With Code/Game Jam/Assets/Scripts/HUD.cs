using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [Header("Stamina UI")]
    [SerializeField] private Slider staminaBar;
    [SerializeField] private MultiplayerPlayerMovement playerMovement;

    [Header("Health UI")]
    [SerializeField] private Slider healthBar;
    [SerializeField] private Health playerHealth;

    private void Start()
    {
        if (staminaBar != null && playerMovement != null)
        {
            staminaBar.minValue = 0;
            staminaBar.maxValue = playerMovement.MaxStamina;
        }

        if (healthBar != null && playerHealth != null)
        {
            healthBar.minValue = 0;
            healthBar.maxValue = playerHealth.MaxHealth;
            healthBar.value = playerHealth.MaxHealth;
        }
    }

    private void Update()
    {
        if (staminaBar != null && playerMovement != null)
            staminaBar.value = playerMovement.CurrentStamina;

        if (healthBar != null && playerHealth != null)
            healthBar.value = playerHealth.CurrentHealth;
    }
}