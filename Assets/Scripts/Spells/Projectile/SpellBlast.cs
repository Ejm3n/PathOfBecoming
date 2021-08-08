using System.Collections;
using UnityEngine;

public class SpellBlast : MonoBehaviour
{
    //Spell projectile
    [SerializeField] float speed;
    [SerializeField] float timeToLive;
    public SpellType spellType { get; private set; }

    Vector3 direction;

    private void Awake()
    {
        StartCoroutine(Time_To_Live());
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.z = 0;
        direction = diff.normalized;
        spellType = Interface.current.spellBook.chosenSpell.spellType;
    }

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    IEnumerator Time_To_Live()
    {
        yield return new WaitForSeconds(timeToLive);
        Destroy(gameObject);
    }
}
