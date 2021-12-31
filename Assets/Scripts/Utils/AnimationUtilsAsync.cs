using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace AnimationUtilsAsync
{
    namespace TransformUtils
    {
        public static class TransformUtils
        {


            public static void Move_To(this Transform obj, Vector3 target, float timeToSlide, Action onComplete = null, bool timeScale = true)
            {
                if (obj.gameObject.TryGetComponent(out LoaderAsync loader))
                    loader.Move_To(obj, target, timeToSlide, onComplete, timeScale);
                else
                    obj.gameObject.AddComponent<LoaderAsync>().Move_To(obj, target, timeToSlide, onComplete, timeScale);
            }
        }

        public class LoaderAsync : MonoBehaviour
        {
            Task sliding;
            const float EPS = 0.0001f;

            public void Move_To(Transform obj, Vector3 target, float timeToSlide, Action onComplete = null, bool timeScale = true)
            {
                if (sliding == null || sliding.IsCompleted)
                    sliding = Move_ToAsync(obj, target, timeToSlide, onComplete, timeScale);
                else
                    return;
            }

            async Task Move_ToAsync(Transform obj, Vector3 target, float timeToSlide, Action onComplete = null, bool timeScale = true)
            {
                float timetoWait = timeScale ? Time.deltaTime : Time.unscaledDeltaTime;
                Vector3 iter = (target - obj.position) / timeToSlide;
                while (Mathf.Abs(obj.position.sqrMagnitude - target.sqrMagnitude) > EPS)
                {
                    iter = ((target - obj.position).sqrMagnitude <= (iter * timetoWait).sqrMagnitude) ? (target - obj.position) / timetoWait : iter;
                    obj.position += iter * timetoWait;
                    await Task.Yield();
                }

                onComplete?.Invoke();
            }
        }
    }
}
