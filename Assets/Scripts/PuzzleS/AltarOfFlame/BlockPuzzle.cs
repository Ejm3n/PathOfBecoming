using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BlockPuzzle : Puzzle
{
    [SerializeField] private int manaCount;
    [HideInInspector] public int CurrentMana;
    [SerializeField] int razlomStrength;
    Stolb[] stolbs;
    public bool GameEnded = false;
    private void Awake()
    {
        CurrentMana = manaCount;
        stolbs = GetComponentsInChildren<Stolb>();
    }
    public void Restart()
    {
        CurrentMana = manaCount;
        foreach(Stolb stolb in stolbs)
        {
            stolb.ResetBlocks();
        }
    }
    private void Update()
    {
        GameEnded = CheckEnd();
        if (GameEnded)
            Solve_Puzzle();
    }
    private bool CheckEnd()
    {
        bool ended = true;

        foreach (Stolb stolb in stolbs)
        {
            if (!stolb.fullStolb)
            {
                
                ended = false;
            }
        }
        
        return ended;
    }
    public void DoRazlom(int stolbNum)
    {

        stolbs[stolbNum].AddRazlomPower(razlomStrength);
    }
    public void AllowOrNoClicks(bool what)
    {
        foreach(Stolb stolb in stolbs)
        {
            stolb.clickable = what;
        }
    }
}
