using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    public const int DAILY_WATER_AMMOUNT = 3000;
    public const int DAILY_SLEEP_AMMOUNT = 480;
    public const int MAX_PLANTS = 12;

    static int waterSaved = 0;
    static int minutesSleepSaved = 0;

    static int coins = 10;

    static bool dailyWaterObjective;
    static bool dailySleepObjective;

    static List<GameObject> plantsOwned = new List<GameObject>();

    public static int getWaterSaved() 
    {
        return waterSaved;
    }

    public static void addWaterSaved(int waterAmmount)
    {
        if(waterAmmount >= 0) waterSaved += waterAmmount;
        if (waterSaved >= DAILY_WATER_AMMOUNT) dailyWaterObjective = true;
    }

    public static int getTotalMinutesSleepSaved()
    {
        return minutesSleepSaved;
    }

    public static int getOnlyHoursSleepSaved()
    {
        return minutesSleepSaved / 60;
    }
    public static int getOnlyMinutesSleepSaved()
    {
        return minutesSleepSaved - ((minutesSleepSaved / 60) * 60);
    }

    public static void addMinutesSleepSaved(int sleepAmmount)
    {
        if (sleepAmmount >= 0) minutesSleepSaved += sleepAmmount;
        if (minutesSleepSaved >= DAILY_SLEEP_AMMOUNT) dailySleepObjective = true;
    }

    public static bool getDailyWaterObjective() 
    {
        return dailyWaterObjective;
    }

    public static bool getDailySleepObjective()
    {
        return dailySleepObjective;
    }

    public static int getCoins() 
    {
        return coins;
    }

    public static bool addCoins(int value) 
    {
        coins += value;
        return true;
    }

    public static bool removeCoins(int value) 
    {
        if (coins - value < 0) 
        {
            return false;
        }

        coins -= value;
        return true;
    }

    public static List<GameObject> getPlantsOwned() 
    {
        return plantsOwned;
    }

    public static bool addPlantsOwned(GameObject plant) 
    {
        if (plantsOwned.Count >= MAX_PLANTS) 
        {
            return false;
        }

        plantsOwned.Add(plant);
        return true;
    }
}
