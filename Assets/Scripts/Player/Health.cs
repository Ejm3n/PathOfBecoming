using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image healthBar;
    public float maxHealth;
    float currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
        healthBar.fillAmount = 1;
    }

    void Change_Health(float value)
    {
        currentHealth = Mathf.Clamp(currentHealth + value, 0, maxHealth);
        healthBar.fillAmount = currentHealth / maxHealth;
    }

    public void Set_Health(float health)
    {
        currentHealth = Mathf.Clamp(health, 0, maxHealth);
        healthBar.fillAmount = currentHealth / maxHealth;
    }

    public void Damage(float damage)
    {
       Change_Health(-damage);
        if (currentHealth == 0)
            Die();
    }

    public void Heal(float heal)
    {
        Change_Health(heal);
    }

    public void Die()
    {
        //when person dies
    }
}
