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

    public static class Prefabs
    {
        public static GameObject PLAYER = Resources.Load<GameObject>("Prefabs/Characters/Player");
        public static GameObject FAIRY = Resources.Load<GameObject>("Prefabs/Characters/Fairy");
    }

    public static class Paths
    {
        public static string SAVEDATAPATH = Application.persistentDataPath + "/savedata.dat";
        public static string GAMEDATAPATH = Application.persistentDataPath + "/gamedata.dat";
    }

    public static class Sounds
    {
        public static AudioClip[] PLAYERSTEPFORESTSOUNDS = Resources.LoadAll<AudioClip>("Sounds/Effects/Footsteps/Forest");
        public static AudioClip PLAYERJUMPSOUND = Resources.Load<AudioClip>("Sounds/Effects/Footsteps/jump");

        public static AudioClip RIDDLESOUND = Resources.Load<AudioClip>("Sounds/Effects/Puzzle/riddle");
        public static AudioClip SOLVESOUND = Resources.Load<AudioClip>("Sounds/Effects/Puzzle/solve");
    }
}