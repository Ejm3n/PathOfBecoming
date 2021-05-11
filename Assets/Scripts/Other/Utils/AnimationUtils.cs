using System.Collections;
using UnityEngine;
using GlobalVariables;
using System;

namespace AnimationUtils
{
    namespace RenderUtils
    {
        public static class RenderUtils
        {
            public static Coroutine Fade(this SpriteRenderer renderer, float timeToFade, bool timeScale = true)
            {
                renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 1);
                if (renderer.gameObject.TryGetComponent(out CoroutineLoader loader))
                    return loader.Start_Change_Transparency(renderer, true, timeToFade, timeScale);
                return renderer.gameObject.AddComponent<CoroutineLoader>().Start_Change_Transparency(renderer, true, timeToFade, timeScale);
            }

            public static Coroutine Fade(this SpriteRenderer renderer, float timeToFade, Action onComplete, bool timeScale = true)
            {
                renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 1);
                if (renderer.gameObject.TryGetComponent(out CoroutineLoader loader))
                    return loader.Start_Change_Transparency(renderer, true, timeToFade, onComplete, timeScale);
                return renderer.gameObject.AddComponent<CoroutineLoader>().Start_Change_Transparency(renderer, true, timeToFade, onComplete, timeScale);
            }

            public static Coroutine Unfade(this SpriteRenderer renderer, float timeToFade, bool timeScale = true)
            {
                renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 0);
                if (renderer.gameObject.TryGetComponent(out CoroutineLoader loader))
                    return loader.Start_Change_Transparency(renderer, false, timeToFade, timeScale);
                return renderer.gameObject.AddComponent<CoroutineLoader>().Start_Change_Transparency(renderer, false, timeToFade, timeScale);
            }

            public static Coroutine Unfade(this SpriteRenderer renderer, float timeToFade, Action onComplete, bool timeScale = true)
            {
                renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 0);
                if (renderer.gameObject.TryGetComponent(out CoroutineLoader loader))
                    return loader.Start_Change_Transparency(renderer, false, timeToFade, onComplete, timeScale);
                return renderer.gameObject.AddComponent<CoroutineLoader>().Start_Change_Transparency(renderer, false, timeToFade, onComplete, timeScale);
            }
        }
    }

    namespace TransformUtils
    {
        public static class TransformUtils
        {
            public static Coroutine SpringRotation(this Transform obj, float timeToRotate, Vector3 rotationAxis, bool timeScale = true)
            {
                AnimationCurve curve = ScriptableObjects.CURVESAMPLES.smoothWithSpring;
                if (obj.gameObject.TryGetComponent(out CoroutineLoader loader))
                    return loader.Start_Curved_Rotation(obj, timeToRotate, curve, rotationAxis, timeScale);
                return obj.gameObject.AddComponent<CoroutineLoader>().Start_Curved_Rotation(obj, timeToRotate, curve, rotationAxis, timeScale);
            }
            public static Coroutine SpringRotation(this Transform obj, float timeToRotate, Vector3 rotationAxis, Action onComplete, bool timeScale = true)
            {
                AnimationCurve curve = ScriptableObjects.CURVESAMPLES.smoothWithSpring;
                if (obj.gameObject.TryGetComponent(out CoroutineLoader loader))
                    return loader.Start_Curved_Rotation(obj, timeToRotate, curve, rotationAxis, onComplete, timeScale);
                return obj.gameObject.AddComponent<CoroutineLoader>().Start_Curved_Rotation(obj, timeToRotate, curve, rotationAxis, onComplete, timeScale);
            }
        }
    }

    public class CoroutineLoader : MonoBehaviour
    {
        #region Change_Transparency
        public Coroutine Start_Change_Transparency(SpriteRenderer renderer, bool makeTransparent, float processTime, bool timeScale = true)
        {
            return StartCoroutine(Change_Transparency(renderer, makeTransparent, processTime, timeScale));
        }

        public Coroutine Start_Change_Transparency(SpriteRenderer renderer, bool makeTransparent, float processTime, Action onComplete, bool timeScale = true)
        {
            return StartCoroutine(Change_Transparency(renderer, makeTransparent, processTime, onComplete, timeScale));
        }

        IEnumerator Change_Transparency(SpriteRenderer renderer, bool makeTransparent, float processTime, bool timeScale = true)
        {
            float alpha = makeTransparent ? 0 : 1;
            float timetoWait = timeScale ? Time.fixedDeltaTime : Time.fixedUnscaledDeltaTime;
            float iter = (alpha - renderer.color.a) / processTime;
            while (renderer.color.a != alpha)
            {
                renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, Mathf.Clamp(renderer.color.a + iter * timetoWait, 0, 1));
                if (timeScale)
                    yield return new WaitForSeconds(timetoWait);
                else
                    yield return new WaitForSecondsRealtime(timetoWait);
            }
        }

        IEnumerator Change_Transparency(SpriteRenderer renderer, bool makeTransparent, float processTime, Action onComplete, bool timeScale = true)
        {
            yield return StartCoroutine(Change_Transparency(renderer, makeTransparent, processTime, timeScale));
            onComplete();
        }

        #endregion Change_Transparency

        #region Curved_Rotation

        bool rotating = false;

        public Coroutine Start_Curved_Rotation(Transform obj, float timeToRotate, AnimationCurve curve, Vector3 rotationAxis, bool timeScale = true)
        {
            if (rotating)
                return null;
            return StartCoroutine(Curved_Rotation(obj, timeToRotate, curve, rotationAxis, timeScale));
        }

        public Coroutine Start_Curved_Rotation(Transform obj, float timeToRotate, AnimationCurve curve, Vector3 rotationAxis, Action onComplete, bool timeScale = true)
        {
            if (rotating)
                return null;
            return StartCoroutine(Curved_Rotation(obj, timeToRotate, curve, rotationAxis, onComplete, timeScale));
        }

        IEnumerator Curved_Rotation(Transform obj, float timeToRotate, AnimationCurve curve, Vector3 rotationAxis, bool timeScale = true)
        {
            rotating = true;
            float timetoWait = timeScale ? Time.fixedDeltaTime : Time.fixedUnscaledDeltaTime;

            float startTime = timeScale ? Time.time : Time.unscaledTime;
            float currentTime;
            float timePassed = 0;

            Vector3 currentRotation = obj.localRotation.eulerAngles;

            while (timePassed < 1)
            {
                currentTime = timeScale ? Time.time : Time.unscaledTime;
                timePassed = (currentTime - startTime) / timeToRotate;

                obj.localRotation = Quaternion.Euler(currentRotation + rotationAxis * curve.Evaluate(timePassed));

                if (timeScale)
                    yield return new WaitForSeconds(timetoWait);
                else
                    yield return new WaitForSecondsRealtime(timetoWait);
            }
            obj.localRotation = Quaternion.Euler(currentRotation + rotationAxis * curve.Evaluate(1));
            rotating = false;
        }

        IEnumerator Curved_Rotation(Transform obj, float timeToRotate, AnimationCurve curve, Vector3 rotationAxis, Action onComplete, bool timeScale = true)
        {
            yield return StartCoroutine(Curved_Rotation(obj, timeToRotate, curve, rotationAxis, timeScale));
            onComplete();
        }

        #endregion Curved_Rotation
    }
}