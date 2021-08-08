using UnityEngine;

namespace GlobalVariables
{
    public static class ScriptableObjects
    {
        public static CurveSamples CURVESAMPLES = Resources.Load<CurveSamples>("ScriptableObjects/CurveSamples");
    }

    public static class Paths
    {
        public static string SAVEDATAPATH = Application.persistentDataPath + "/savedata.dat";
        public static string GAMEDATAPATH = Application.persistentDataPath + "/gamedata.dat";
    }

    public static class Sounds
    {
        public static AudioClip RIDDLESOUND = Resources.Load<AudioClip>("Sounds/Effects/Puzzle/riddle");
        public static AudioClip SOLVESOUND = Resources.Load<AudioClip>("Sounds/Effects/Puzzle/solve");
    }
}