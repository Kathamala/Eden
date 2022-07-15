using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [HideInInspector] public delegate void UserDrankWater(int amountDrank);
    [HideInInspector] public static event UserDrankWater UserDrankWaterEvent;
    public static void UpdateWaterDrank(int waterAmount)
    {
        UserDrankWaterEvent?.Invoke(waterAmount);
    }

}
