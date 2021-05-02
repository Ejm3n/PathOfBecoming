using UnityEngine;

namespace GlobalVariables
{
    namespace PuzzleVariables
    {
        public static class Prefabs
        {
            //Cat puzzle
            public static GameObject CHIPPREFAB = Resources.Load<GameObject>("Prefabs/Puzzles/CatPuzzle/Chips/Chip");
            public static GameObject CATCHIPPREFAB = Resources.Load<GameObject>("Prefabs/Puzzles/CatPuzzle/Chips/CatChip");
            public static GameObject MOUSECHIPPREFAB = Resources.Load<GameObject>("Prefabs/Puzzles/CatPuzzle/Chips/MouseChip");
            public static GameObject HOLECHIPPREFAB = Resources.Load<GameObject>("Prefabs/Puzzles/CatPuzzle/Chips/HoleChip");
            public static GameObject CATPUZZLEPREFAB = Resources.Load<GameObject>("Prefabs/Puzzles/CatPuzzle/CatPuzzle");

            //brick puzzle
            public static GameObject BRICKPUZZLEPREFAB = Resources.Load<GameObject>("Prefabs/Puzzles/CatPuzzle/CatPuzzle");
        }

        public static class Sprites
        {
            //Cat puzzle
            public static Sprite[] MICESPRITES = Resources.LoadAll<Sprite>("Sprites/Puzzles/CatPuzzle/Mice");
        }
    }
}
