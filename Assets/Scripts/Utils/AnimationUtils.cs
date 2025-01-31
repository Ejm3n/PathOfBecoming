﻿using System.Collections;
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

            public static Coroutine Change_Colour(this SpriteRenderer renderer, Color colorTo, float timeToChange)
            {
                if (renderer.gameObject.TryGetComponent(out CoroutineLoader loader))
                    return loader.Start_Gradient(renderer, colorTo, timeToChange);
                return renderer.gameObject.AddComponent<CoroutineLoader>().Start_Gradient(renderer, colorTo, timeToChange);
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

    namespace TextUtils
    {
        public static class TextUtils
        {
            public static Coroutine Fade(this Text text, float timeToFade, bool timeScale = true)
            {
                text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
                if (text.gameObject.TryGetComponent(out CoroutineLoader loader))
                    return loader.Start_Change_Transparency(text, true, timeToFade, timeScale);
                return text.gameObject.AddComponent<CoroutineLoader>().Start_Change_Transparency(text, true, timeToFade, timeScale);
            }

            public static Coroutine Fade(this Text text, float timeToFade, Action onComplete, bool timeScale = true)
            {
                text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
                if (text.gameObject.TryGetComponent(out CoroutineLoader loader))
                    return loader.Start_Change_Transparency(text, true, timeToFade, timeScale, onComplete);
                return text.gameObject.AddComponent<CoroutineLoader>().Start_Change_Transparency(text, true, timeToFade, timeScale, onComplete);
            }

            public static Coroutine Unfade(this Text text, float timeToFade, bool timeScale = true)
            {
                text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
                if (text.gameObject.TryGetComponent(out CoroutineLoader loader))
                    return loader.Start_Change_Transparency(text, false, timeToFade, timeScale);
                return text.gameObject.AddComponent<CoroutineLoader>().Start_Change_Transparency(text, false, timeToFade, timeScale);
            }

            public static Coroutine Unfade(this Text text, float timeToFade, Action onComplete, bool timeScale = true)
            {
                text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
                if (text.gameObject.TryGetComponent(out CoroutineLoader loader))
                    return loader.Start_Change_Transparency(text, false, timeToFade, timeScale, onComplete);
                return text.gameObject.AddComponent<CoroutineLoader>().Start_Change_Transparency(text, false, timeToFade, timeScale, onComplete);
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
            public static Coroutine Move_To(this Transform obj, Vector3 target, float timeToSlide, bool waitslide = true, Action onComplete = null, bool timeScale = true)
            {
                if (obj.gameObject.TryGetComponent(out CoroutineLoader loader))
                    return loader.Start_Slide(obj, target, timeToSlide, timeScale, onComplete, waitslide);
                return obj.gameObject.AddComponent<CoroutineLoader>().Start_Slide(obj, target, timeToSlide, timeScale, onComplete, waitslide);
            }
        }
    }

    public class CoroutineLoader : MonoBehaviour
    {
        const float EPS = 0.001f;
        
        #region Change_Transparency

        Coroutine transparencyRendererCoroutine;
        Coroutine transparencyImageCoroutine;
        public Coroutine Start_Change_Transparency(SpriteRenderer renderer, bool makeTransparent, float processTime, bool timeScale = true, Action onComplete = null)
        {
            if (transparencyRendererCoroutine != null)
                StopCoroutine(transparencyRendererCoroutine);
            transparencyRendererCoroutine = StartCoroutine(Change_Transparency(renderer, makeTransparent, processTime, timeScale, onComplete));
            return transparencyRendererCoroutine;
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
            if (transparencyImageCoroutine != null)
                StopCoroutine(transparencyImageCoroutine);
            transparencyImageCoroutine = StartCoroutine(Change_Transparency(image, makeTransparent, processTime, timeScale, onComplete));
            return transparencyImageCoroutine;
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

        public Coroutine Start_Change_Transparency(Text text, bool makeTransparent, float processTime, bool timeScale = true, Action onComplete = null)
        {
            if (transparencyImageCoroutine != null)
                StopCoroutine(transparencyImageCoroutine);
            transparencyImageCoroutine = StartCoroutine(Change_Transparency(text, makeTransparent, processTime, timeScale, onComplete));
            return transparencyImageCoroutine;
        }

        IEnumerator Change_Transparency(Text text, bool makeTransparent, float processTime, bool timeScale = true, Action onComplete = null)
        {
            float alpha = makeTransparent ? 0 : 1;
            float timetoWait = timeScale ? Time.fixedDeltaTime : Time.fixedUnscaledDeltaTime;
            float iter = (alpha - text.color.a) / processTime;
            while (text.color.a != alpha)
            {
                text.color = new Color(text.color.r, text.color.g, text.color.b, Mathf.Clamp(text.color.a + iter * timetoWait, 0, 1));
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

        bool sliding = false;
        Coroutine slidingCoroutine;
        public Coroutine Start_Slide(Transform transform, Vector3 target, float processTime, bool timeScale = true, Action onComplete = null, bool waitslide = true)
        {
            if (sliding && waitslide)
                return null;
            if (slidingCoroutine != null)
                StopCoroutine(slidingCoroutine);
            slidingCoroutine = StartCoroutine(Slide(transform, target, processTime, timeScale, onComplete));
            return slidingCoroutine;
        }

        IEnumerator Slide(Transform transform, Vector3 target, float processTime, bool timeScale = true, Action onComplete = null)
        {
            sliding = true;
            float timetoWait = timeScale ? Time.fixedDeltaTime : Time.fixedUnscaledDeltaTime;
            Vector3 iter = (target - transform.position) / processTime;
            float _startTime = timeScale ? Time.time : Time.unscaledTime;
            float _currentTime;
            while (Mathf.Abs(target.sqrMagnitude - transform.position.sqrMagnitude) > EPS)
            {
                transform.position += iter * timetoWait;
                yield return null;
                _currentTime = timeScale ? Time.time : Time.unscaledTime;
                if ((_currentTime - _startTime) >= processTime * 1.1f)
                    break;
            }
            transform.position = target;
            onComplete?.Invoke();
            sliding = false;
        }
        #endregion Slide

        #region Gradient
        Coroutine gradientCoroutine;

        public Coroutine Start_Gradient(SpriteRenderer renderer, Color colorTo, float processTime)
        {
            if (gradientCoroutine != null)
                StopCoroutine(gradientCoroutine);
            gradientCoroutine = StartCoroutine(Gradient(renderer, colorTo, processTime));
            return gradientCoroutine;
        }

        IEnumerator Gradient(SpriteRenderer renderer, Color colorTo, float processTime)
        {
            float red = (colorTo.r - renderer.color.r) / processTime;
            float green = (colorTo.g - renderer.color.g) / processTime;
            float blue = (colorTo.b - renderer.color.b) / processTime;
            while (Mathf.Abs(renderer.color.r - colorTo.r) > EPS &&
                   Mathf.Abs(renderer.color.g - colorTo.g) > EPS &&
                   Mathf.Abs(renderer.color.b - colorTo.b) > EPS)
            {
                renderer.color = new Color(renderer.color.r + (red * Time.deltaTime),
                                           renderer.color.g + (green * Time.deltaTime),
                                           renderer.color.b + (blue * Time.deltaTime));
                yield return null;
            }
        }
        #endregion Gradient
    }
}