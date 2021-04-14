using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TransitionBetweenScenes : MonoBehaviour
{
    [SerializeField] private Animator fadeAnimator;
    [SerializeField] private int loadLevel; // загружаемый уровень
    public bool CanULoadNextLvl;
    private float fadeLength; // длина анимации

    /// <summary>
    /// Затухание
    /// </summary>
    public void FadeComplete()
    {
        fadeAnimator.SetTrigger("FadeIn");
        StartCoroutine(LoadScene());
    }

    /// <summary>
    /// Загрузка сцены
    /// </summary>
    /// <returns></returns>
    IEnumerator LoadScene()
    {
        GetAnimationTime();
        yield return new WaitForSeconds(fadeLength);
        SceneManager.LoadScene(loadLevel);
    }

    /// <summary>
    /// Получаем длину анимации, чтобы ничего не сломалось при ее изменении
    /// </summary>
    public void GetAnimationTime()
    {
        AnimationClip[] clip = fadeAnimator.runtimeAnimatorController.animationClips;
        foreach (AnimationClip animClip in clip)
        {
            if (animClip.name.Equals("FadeOut"))
            {
                fadeLength = animClip.length;
                Debug.Log(fadeLength);
            }
        }
    }
    private void OnMouseUp()
    {
        if (CanULoadNextLvl)
            FadeComplete();
    }
}
