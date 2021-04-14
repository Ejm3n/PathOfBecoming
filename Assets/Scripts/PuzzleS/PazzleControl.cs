using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PazzleControl : MonoBehaviour
{
    [SerializeField]
    private RectTransform[] hexagon;
    private Animator anim;
    [SerializeField]
    private GameObject PzGame;
    [SerializeField]
    private SpriteRenderer cage;
    [SerializeField]
    private SpriteRenderer dor;
    [SerializeField]
    private SpriteRenderer cageBack;
    [SerializeField] GameObject dialogueToActivate;
    [SerializeField] GameObject dialogueIfClosed;
    public static bool youWin;
    [SerializeField] DialogueSystem ds;

    private void Start()
    {
        youWin = false;
        anim = GetComponent<Animator>();

        int r = Random.Range(1, 5);
        hexagon[0].transform.Rotate(0, 0, 60 * r);
        hexagon[1].transform.Rotate(0, 0, -60 * r);
        hexagon[2].transform.Rotate(0, 0, 60 * r);
        hexagon[3].transform.Rotate(0, 0, -60 * r);
        hexagon[4].transform.Rotate(0, 0, 60 * r);
        hexagon[5].transform.Rotate(0, 0, -60 * r);
        hexagon[6].transform.Rotate(0, 0, 60 * r);
        anim.SetBool("New Bool", false);
    }

    private void Update()
    {
        if (hexagon[0].rotation.z >= -0.0001 && hexagon[0].rotation.z <= 0.0001 &&
            hexagon[1].rotation.z >= -0.0001 && hexagon[1].rotation.z <= 0.0001 &&
            hexagon[2].rotation.z >= -0.0001 && hexagon[2].rotation.z <= 0.0001 &&
            hexagon[3].rotation.z >= -0.0001 && hexagon[3].rotation.z <= 0.0001 &&
            hexagon[4].rotation.z >= -0.0001 && hexagon[4].rotation.z <= 0.0001 &&
            hexagon[5].rotation.z >= -0.0001 && hexagon[5].rotation.z <= 0.0001 &&
            hexagon[6].rotation.z >= -0.0001 && hexagon[6].rotation.z <= 0.0001)
        {
            youWin = true;
            if(dialogueToActivate != null)
            {
                dialogueToActivate.SetActive(true);
            }               
            anim.SetBool("New Bool", true);
            cageBack.sortingOrder = 0;
            cage.sortingOrder = 1;
            dor.sortingOrder = 2;

            StartCoroutine(End());
        }
    }
    public void Exit()
    {
       
        PzGame.SetActive(false);
        if(dialogueIfClosed!=null)
            dialogueIfClosed.SetActive(true);
        else
            ds.SetUI(true);
    }

    IEnumerator With()
    {
        yield return new WaitForSeconds(2f);
        Exit();
    }
    IEnumerator End()//яша добавил 
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
