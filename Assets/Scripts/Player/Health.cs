using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float maxHealth;
    float currentHealth;
    Image healthBar;


    public void Initialise(Image healthBar)
    {
        this.healthBar = healthBar;
    }

    private void Awake()
    {
        currentHealth = maxHealth;
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

    public float Get_Health()
    {
        return currentHealth;
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
