using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    public const int DAILY_WATER_AMMOUNT = 3000;
    public const int DAILY_SLEEP_AMMOUNT = 480;

    static int waterSaved = 0;
    static int minutesSleepSaved = 0;

    public static int getWaterSaved() 
    {
        return waterSaved;
    }

    public static void addWaterSaved(int waterAmmount)
    {
        if(waterAmmount >= 0) waterSaved += waterAmmount;
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
    }
}
