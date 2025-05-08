using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerXP : MonoBehaviour
{
    public delegate void OnGainXP(float xp);
    public static event OnGainXP onGet;
    
    public float CurrentXP, MaxXP;
    public int CurrentLevel = 1;

    public static void CallOnGetXP(float xp)
    {
        onGet?.Invoke(xp);
    }

    private void OnEnable()
    {
        onGet += AddXP;
    }

    private void OnDisable()
    {
        onGet -= AddXP;
    }

    private void AddXP(float xp)
    {
        CurrentXP += xp;
        if (CurrentXP >= MaxXP)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        CurrentXP = 0f;
        MaxXP += 10f;

        CurrentLevel++;
    }
}
