using System.Collections;
using UnityEngine;
using GlobalVariables;
using System;
using UnityEngine.UI;

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
                    return loader.Start_Change_Transparency(renderer, true, timeToFade, timeScale, onComplete);
                return renderer.gameObject.AddComponent<CoroutineLoader>().Start_Change_Transparency(renderer, true, timeToFade, timeScale, onComplete);
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
                    return loader.Start_Change_Transparency(renderer, false, timeToFade, timeScale, onComplete);
                return renderer.gameObject.AddComponent<CoroutineLoader>().Start_Change_Transparency(renderer, false, timeToFade, timeScale, onComplete);
            }
        }
    }

    namespace ImageUtils
    {
        public static class ImageUtils
        {
            public static Coroutine Fade(this Image image, float timeToFade, bool timeScale = true)
            {
                image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
                if (image.gameObject.TryGetComponent(out CoroutineLoader loader))
                    return loader.Start_Change_Transparency(image, true, timeToFade, timeScale);
                return image.gameObject.AddComponent<CoroutineLoader>().Start_Change_Transparency(image, true, timeToFade, timeScale);
            }

            public static Coroutine Fade(this Image image, float timeToFade, Action onComplete, bool timeScale = true)
            {
                image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
                if (image.gameObject.TryGetComponent(out CoroutineLoader loader))
                    return loader.Start_Change_Transparency(image, true, timeToFade, timeScale, onComplete);
                return image.gameObject.AddComponent<CoroutineLoader>().Start_Change_Transparency(image, true, timeToFade, timeScale, onComplete);
            }

            public static Coroutine Unfade(this Image image, float timeToFade, bool timeScale = true)
            {
                image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
                if (image.gameObject.TryGetComponent(out CoroutineLoader loader))
                    return loader.Start_Change_Transparency(image, false, timeToFade, timeScale);
                return image.gameObject.AddComponent<CoroutineLoader>().Start_Change_Transparency(image, false, timeToFade, timeScale);
            }

            public static Coroutine Unfade(this Image image, float timeToFade, Action onComplete, bool timeScale = true)
            {
                image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
                if (image.gameObject.TryGetComponent(out CoroutineLoader loader))
                    return loader.Start_Change_Transparency(image, false, timeToFade, timeScale, onComplete);
                return image.gameObject.AddComponent<CoroutineLoader>().Start_Change_Transparency(image, false, timeToFade, timeScale, onComplete);
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
            public static Coroutine Move_To(this Transform obj, Vector3 target, float timeToSlide, Action onComplete = null, bool timeScale = true)
            {
                if (obj.gameObject.TryGetComponent(out CoroutineLoader loader))
                    return loader.Start_Slide(obj, target, timeToSlide, timeScale, onComplete);
                return obj.gameObject.AddComponent<CoroutineLoader>().Start_Slide(obj, target, timeToSlide, timeScale, onComplete);
            }
        }
    }

    public class CoroutineLoader : MonoBehaviour
    {
        #region Change_Transparency
        public Coroutine Start_Change_Transparency(SpriteRenderer renderer, bool makeTransparent, float processTime, bool timeScale = true, Action onComplete = null)
        {
            return StartCoroutine(Change_Transparency(renderer, makeTransparent, processTime, timeScale, onComplete));
        }

        IEnumerator Change_Transparency(SpriteRenderer renderer, bool makeTransparent, float processTime, bool timeScale = true, Action onComplete = null)
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
            onComplete?.Invoke();
        }

        public Coroutine Start_Change_Transparency(Image image, bool makeTransparent, float processTime, bool timeScale = true, Action onComplete = null)
        {
            return StartCoroutine(Change_Transparency(image, makeTransparent, processTime, timeScale, onComplete));
        }

        IEnumerator Change_Transparency(Image image, bool makeTransparent, float processTime, bool timeScale = true, Action onComplete = null)
        {
            float alpha = makeTransparent ? 0 : 1;
            float timetoWait = timeScale ? Time.fixedDeltaTime : Time.fixedUnscaledDeltaTime;
            float iter = (alpha - image.color.a) / processTime;
            while (image.color.a != alpha)
            {
                image.color = new Color(image.color.r, image.color.g, image.color.b, Mathf.Clamp(image.color.a + iter * timetoWait, 0, 1));
                if (timeScale)
                    yield return new WaitForSeconds(timetoWait);
                else
                    yield return new WaitForSecondsRealtime(timetoWait);
            }
            onComplete?.Invoke();
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

        #region Slide
        public Coroutine Start_Slide(Transform transform, Vector3 target, float processTime, bool timeScale = true, Action onComplete = null)
        {
            return StartCoroutine(Slide(transform, target, processTime, timeScale, onComplete));
        }

        IEnumerator Slide(Transform transform, Vector3 target, float processTime, bool timeScale = true, Action onComplete = null)
        {
            const float EPS = 0.0001f;
            float timetoWait = timeScale ? Time.fixedDeltaTime : Time.fixedUnscaledDeltaTime;
            Vector3 iter = (target - transform.position) / processTime;
            while((target - transform.position).sqrMagnitude > EPS)
            {
                transform.position += iter * timetoWait;
                if (timeScale)
                    yield return new WaitForSeconds(timetoWait);
                else
                    yield return new WaitForSecondsRealtime(timetoWait);
            }
            onComplete?.Invoke();
        }
        #endregion
    }
}