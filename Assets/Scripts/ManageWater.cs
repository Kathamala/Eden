using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageWater : MonoBehaviour
{
    [SerializeField] Text waterInput;
    [SerializeField] Text totalWaterText;
    [SerializeField] WaterTankFill waterTankFill;

    public void saveWater()
    {
        if (!validateInputs()) { return; }

        int water = int.Parse(waterInput.text);

        GameDataManager.addWaterSaved(water);

        updateWaterTexts();
        updateWaterTank();
        //Debug.Log("OK");
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

        totalWaterText.text = totalWater.ToString();
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
