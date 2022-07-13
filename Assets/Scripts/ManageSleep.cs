using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManageSleep : MonoBehaviour
{

    [SerializeField] TMP_InputField hoursInput;
    [SerializeField] TMP_InputField minutesInput;
    [SerializeField] TextMeshProUGUI totalHoursSleptText;
    [SerializeField] TextMeshProUGUI totalMinutesSleptText;

    [SerializeField] TextMeshProUGUI dreamcoinText;

    [SerializeField] AudioManager audioManager;

    private bool dailyObjMet = false;

    public void saveTimeSlept() 
    {
        if (!validateInputs()) { return; }
        int hours = 0;
        int minutes = 0;
        if (hoursInput.text != "")
        {
            hours = int.Parse(hoursInput.text);
        }
        if(minutesInput.text != "")
        {
            minutes = int.Parse(minutesInput.text);
        }

        GameDataManager.addMinutesSleepSaved((hours*60) + minutes);
        GameDataManager.addCoins(hours);

        updateSleepTexts();
        updateCoinsText();
        playConfirmationSound();
        dailyObjMet = GameDataManager.getDailySleepObjective();
        //Debug.Log("OK");
    }

    public void playConfirmationSound()
    {
        if (GameDataManager.getTotalMinutesSleepSaved() >= GameDataManager.DAILY_SLEEP_AMMOUNT && !dailyObjMet)
        {
            audioManager.playDailyObjective();
        }
        else
        {
            audioManager.playWaterSleepAdded();
        }
    }

    bool validateInputs() 
    {
        if (hoursInput.text == "" && minutesInput.text == "")
        {
            //Debug.Log("Hours and minutes can't be empty!");
            return false;
        }
        /*
        if (minutesInput.text == "")
        {
            //Debug.Log("Minutes can't be empty!");
            return false;
        }*/
        if(hoursInput.text != "")
        {
            if (int.Parse(hoursInput.text) < 0)
            {
                //Debug.Log("Hours can't be negative!");
                return false;
            }
        }
        if(minutesInput.text != "")
        {
            if (int.Parse(minutesInput.text) < 0)
            {
                //Debug.Log("Minutes can't be negative!");
                return false;
            }
            if (int.Parse(minutesInput.text) >= 60)
            {
                //Debug.Log("Minutes can't be greater than 59!");
                return false;
            }
        }
        

        return true;
    }

    void updateSleepTexts() 
    {
        int totalHours = GameDataManager.getOnlyHoursSleepSaved();
        int totalMinutes = GameDataManager.getOnlyMinutesSleepSaved();

        totalHoursSleptText.text = totalHours.ToString();
        totalMinutesSleptText.text = totalMinutes.ToString();
    }

    void updateCoinsText()
    {
        int totalDreamcoins = GameDataManager.getCoins();

        dreamcoinText.text = totalDreamcoins.ToString();
    }
}
