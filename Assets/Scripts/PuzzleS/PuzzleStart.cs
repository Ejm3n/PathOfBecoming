using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class PuzzleStart : MonoBehaviour
{
    public GameObject Pazzle;
    public bool canUStart = false;
    [SerializeField] GameObject canvas;
    [SerializeField] DialogueSystem ds;
    public void OnMouseUp()
    {
        if(!this.IsPointerOverUIObject() && Pazzle !=null && canUStart)
        {
            Pazzle.SetActive(true);
            ds.SetUI(false);
        }      
    }
    private bool IsPointerOverUIObject()
    {
        // get current pointer position and raycast it
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

        // check if the target is in the UI
        foreach (RaycastResult r in results)
        {
            bool isUIClick = r.gameObject.transform.IsChildOf(this.canvas.transform);
            if (isUIClick)
            {
                return true;
            }
        }
        return false;
    }
}

