using System.Collections;
using UnityEngine;

public class TreeTrigger : SpellTrigger
{
    [SerializeField] Collider2D playerBlocker;
    [SerializeField] Joint2D joint;
    [SerializeField] float timeToWait;

    public void Break_Tree()
    {
        StartCoroutine(Proceed());
    }

    IEnumerator Proceed()
    {
        joint.enabled = false;
        yield return new WaitForSeconds(timeToWait);
        playerBlocker.enabled = false;
    }
}
