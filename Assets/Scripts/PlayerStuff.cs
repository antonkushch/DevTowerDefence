using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Interfaces;
using UnityEngine.UI;

public class PlayerStuff : MonoBehaviour
{
    public static int money;
    public int startMoney = 400;
    public static int health;
    public int startHealth = 5;
    public static int wavesSurvived;
    private static int enemiesKilled;
    private static bool gameWon;

    void Start()
    {
        money = startMoney;
        health = startHealth;
        wavesSurvived = 0;
        enemiesKilled = 0;
        gameWon = false;
    }

    public static int GetMoney()
    {
        return money;
    }

    public static void AddMoney(int amount)
    {
        money += amount;
    }

    public static int GetHealth()
    {
        return health;
    }

    public static void DecreaseHealth()
    {
        health--;
    }

    public static void IncrementWavesSurvived()
    {
        wavesSurvived++;
    }

    public static void IncrementEnemiesKilled()
    {
        enemiesKilled++;
    }

    public static int GetEnemiesKilled()
    {
        return enemiesKilled;
    }

    public static void SetGameWon()
    {
        gameWon = true;
    }

    public static bool GetGameWon()
    {
        return gameWon;
    }

    public void OnEnemyReachedEnd()
    {
        health--;
    }
}
