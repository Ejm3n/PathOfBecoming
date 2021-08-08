using System.Collections;
using UnityEngine;

public class PoisonousFumes : MonoBehaviour
{
    public float fumeRecoverTime;
    public float interval;
    public float damagePerInterval;
    public int fumesIntensivity;
    public ParticleSystem fumes;

    ParticleSystem.EmissionModule emModule;
    Health playerHealth;

    Coroutine damageCoroutine;
    Coroutine fumeRestoreCoroutine;

    int fumeLevel;
    bool fumesRestoring;

    private void Awake()
    {
        fumeLevel = fumesIntensivity;
        emModule = fumes.emission;
        emModule.rateOverTime = 10 * fumeLevel;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            Poison(collision.gameObject);
        else //spell
            Blow_Away();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            StopCoroutine(damageCoroutine);
    }

    void Poison(GameObject player)
    {
        playerHealth = player.GetComponent<Health>();
        damageCoroutine = StartCoroutine(Deal_Damage());
    }

    void Blow_Away()
    {
        fumeLevel = Mathf.Max(fumeLevel - 1, 0);
        emModule.rateOverTime = 10 * fumeLevel;
        if (fumesRestoring)
            StopCoroutine(fumeRestoreCoroutine);
        fumeRestoreCoroutine = StartCoroutine(Fumes_Restore());
    }

    IEnumerator Deal_Damage()
    {
        while (true)
        {
            playerHealth.Damage(damagePerInterval * fumeLevel);
            yield return new WaitForSeconds(interval);
        }
    }

    IEnumerator Fumes_Restore()
    {
        fumesRestoring = true;
        while (fumeLevel < fumesIntensivity)
        {
            yield return new WaitForSeconds(fumeRecoverTime);
            ++fumeLevel;
            emModule.rateOverTime = 10 * fumeLevel;
        }
        fumesRestoring = false;
    }
}
