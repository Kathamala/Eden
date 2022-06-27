using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManageWater : MonoBehaviour
{
    [SerializeField] TMP_InputField waterInput;
    [SerializeField] TextMeshProUGUI totalWaterText;
    [SerializeField] WaterTankFill waterTankFill;

    [SerializeField] AudioManager audioManager;

    private bool dailyObjMet = false;

    public void saveWater()
    {
        if (!validateInputs()) { return; }

        int water = int.Parse(waterInput.text);

        GameDataManager.addWaterSaved(water);

        updateWaterTexts();
        updateWaterTank();
        playConfirmationSound();
        dailyObjMet = GameDataManager.getDailyWaterObjective();
        //Debug.Log("OK");
    }

    public void playConfirmationSound() 
    {
        if (GameDataManager.getWaterSaved() >= GameDataManager.DAILY_WATER_AMMOUNT && !dailyObjMet)
        {
            audioManager.playDailyObjective();
        } else 
        {
            audioManager.playWaterSleepAdded();
        }
    }

    bool validateInputs()
    {
        if (waterInput.text == "")
        {
            //Debug.Log("Water ammount can't be empty!");
            return false;
        }
        if (int.Parse(waterInput.text) < 0)
        {
            //Debug.Log("Water ammount can't be negative!");
            return false;
        }

        return true;
    }

    void updateWaterTexts()
    {
        int totalWater = GameDataManager.getWaterSaved();

        totalWaterText.text = totalWater.ToString()+"ml";
    }

    void updateWaterTank() 
    {
        waterTankFill.setWaterFill(GameDataManager.getWaterSaved());
        waterTankFill.SetMaxWater(GameDataManager.DAILY_WATER_AMMOUNT);
    }

    void Start()
    {
        updateWaterTank();
    }
}
