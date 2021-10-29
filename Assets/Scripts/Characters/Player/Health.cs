using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float safeSpeed;
    float currentHealth;
    Image healthBar;

    PlayerController pc;

    float criticalVelocity;


    public void Initialise(Image healthBar)
    {
        this.healthBar = healthBar;
    }

    private void Awake()
    {
        currentHealth = maxHealth;
        pc = GetComponent<PlayerController>();
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
        if (currentHealth == 0)
            return;
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
        pc.Last_Checkpoint();
    }

    private void FixedUpdate()
    {
        if (!pc.isGround && Mathf.Abs(pc.rb.velocity.y) > safeSpeed)
            criticalVelocity = Mathf.Pow(Mathf.Abs(pc.rb.velocity.y) - safeSpeed, 3);
        else if (!pc.isGround && Mathf.Abs(pc.rb.velocity.y) <= safeSpeed)
            criticalVelocity = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Damage(criticalVelocity);
        criticalVelocity = 0;
    }
}
