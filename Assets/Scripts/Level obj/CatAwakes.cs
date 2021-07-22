using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAwakes : MonoBehaviour
{
    [SerializeField] SpriteRenderer catSr;
    [SerializeField] Sprite Awakesprite;
    [SerializeField] GameObject[] nextTriggersAfterTaps;//тут два триггера но они на разные тапы будут включаться
    [SerializeField] HintMap hintMap;
    int i = 0;
    private void OnMouseUp()
    {
        hintMap.Stop_Highlight();
        catSr.sprite = Awakesprite;
        nextTriggersAfterTaps[i].SetActive(true);
        i++;
        gameObject.SetActive(false);
        
    }
}
