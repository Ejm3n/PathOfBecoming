using UnityEngine;

namespace GlobalVariables
{
    public static class SceneIndexes
    {
        public const int MAINMENUSCENEINDEX = 0;
        public const int LEVEL1SCENEINDEX = 1;
        public const int ROOMSCENEINDEX = 2;
    }

    public static class ScriptableObjects
    {
        public static CurveSamples CURVESAMPLES = Resources.Load<CurveSamples>("ScriptableObjects/CurveSamples");
    }
}