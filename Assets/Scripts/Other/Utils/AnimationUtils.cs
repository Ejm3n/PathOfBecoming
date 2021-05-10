using System.Collections;
using UnityEngine;

namespace AnimationUtils
{
    namespace RenderUtils
    {
        public static class RenderUtils
        {
            public static Coroutine Fade(this SpriteRenderer renderer, float timeToFade, bool timeScale = true)
            {
                renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 1);
                return AnimationCoroutines.cl.Start_Change_Transparency(renderer, true, timeToFade, timeScale);
            }

            public static Coroutine Unfade(this SpriteRenderer renderer, float timeToFade, bool timeScale = true)
            {
                renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 0);
                return renderer.gameObject.AddComponent<CoroutineLoader>().Start_Change_Transparency(renderer, false, timeToFade, timeScale);
            }
        }
    }
    static class AnimationCoroutines
    {
        public static CoroutineLoader cl = new CoroutineLoader();
    }

    public class CoroutineLoader : MonoBehaviour
    {
        public Coroutine Start_Change_Transparency(SpriteRenderer renderer, bool makeTransparent, float processTime, bool timeScale = true)
        {
            return StartCoroutine(Change_Transparency(renderer, makeTransparent, processTime, timeScale));
        }

        IEnumerator Change_Transparency(SpriteRenderer renderer, bool makeTransparent, float processTime, bool timeScale = true)
        {
            float alpha = makeTransparent ? 0 : 1;
            float timetoWait = timeScale ? Time.fixedDeltaTime : Time.fixedUnscaledDeltaTime;
            float iter = (alpha - renderer.color.a) / processTime;
            while (renderer.color.a != alpha)
            {
                renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, renderer.color.a + iter * timetoWait);
                if (timeScale)
                    yield return new WaitForSeconds(timetoWait);
                else
                    yield return new WaitForSecondsRealtime(timetoWait);
            }
            Destroy(this);
        }
    }
}