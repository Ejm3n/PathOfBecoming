using System.Collections;
using UnityEngine;

[RequireComponent(typeof(RelativeJoint2D))]
[RequireComponent(typeof(Collider2D))]
public class Follower : MonoBehaviour
{
    [SerializeField] float searchRadius;
    [SerializeField] float timeToLive;

    public SpellType spellType { get; private set; }

    RelativeJoint2D joint;

    private void Awake()
    {
        spellType = Interface.current.spellBook.chosenSpell.spellType;
        joint = GetComponent<RelativeJoint2D>();
        Collider2D player = Physics2D.OverlapCircle(transform.position, searchRadius, 1<<10);
        if (player)
        {
            joint.connectedBody = Engine.current.playerController.fairyAnchor;
            joint.attachedRigidbody.bodyType = RigidbodyType2D.Dynamic;
        }
        else
            StartCoroutine(Time_To_Live());
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

    IEnumerator Time_To_Live()
    {
        yield return new WaitForSeconds(timeToLive);
        Destroy(gameObject);
    }
}
