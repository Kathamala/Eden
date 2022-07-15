using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewDayScript : MonoBehaviour
{
    public void NewDayButtonPressed()
    {
        GameDataManager.StartNewDay();
    }
}
